using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Classes.Models
{
    /// <summary>
    /// Represents a fragmented hard drive.
    /// </summary>
    /// <param name="data">Data on the drive.</param>
    internal class Disk(string diskData)
    {
        /// <summary>
        /// Defragments the dis and returns thenew checksum.
        /// </summary>
        /// <param name="fragment">If true, allows fragmentation of files on disk.</param>
        /// <returns>Checksum.</returns>
        internal long Compress(bool fragment)
        {
            var data = BuildFileSystem();
            if(fragment)
            {
                CompressData(data);
            }
            else
            {
                CompressFiles(data);
            }
            return CalculateChecksum(data);
        }

        private List<int?> BuildFileSystem()
        {
            var data = new List<int?>();
            int file = 0;

            for (int i = 0; i < diskData.Length; i++)
            {
                var size = char.GetNumericValue(diskData[i]);
                if (i % 2 == 0)
                {
                    //even. Use the value in the file variable.
                    for (int j = 0; j < size; j++)
                    {
                        data.Add(file);
                    }
                    file++;
                }
                else
                {
                    //Odd. Use null for empty space.
                    for (int j = 0; j < size; j++)
                    {
                        data.Add(null);
                    }
                }
            }

            return data;
        }

        private static void CompressData(List<int?> data)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (data[i] != null)
                {
                    var newLocation = data.IndexOf(null);
                    if (newLocation >= i)
                    {
                        //Entire disk is compressed at this point.
                        break;
                    }
                    else
                    {
                        data[newLocation] = data[i];
                        data[i] = null;
                    }
                }
            }
        }

        private static void CompressFiles(List<int?> data)
        {
            var diskPtr = data.Count - 1;


            while (diskPtr >= 0)
            {
                FindNextFile(data, ref diskPtr);
                if(diskPtr >= 0)
                {
                    var fileEnd = diskPtr;
                    FindFileStart(data, ref diskPtr);
                    var fileStart = diskPtr;
                    var fileSize = fileEnd - fileStart + 1;
                    var emptySpaceStart = FindEmptySpace(data, fileSize, fileStart - 1);
                    if(emptySpaceStart < fileStart)
                    {
                        MoveFile(data, fileStart, fileSize, emptySpaceStart);
                    }
                    //diskPtr is at start of file. Move back one.
                    diskPtr--;
                }
            }
        }

        private static void MoveFile(List<int?> data, int fileStart, int fileSize, int moveTo)
        {
            for (int i = 0; i < fileSize; i++)
            {
                data[moveTo + i] = data[fileStart + i];
                data[fileStart + i] = null;
            }
        }

        private static int FindEmptySpace(List<int?> data, int size, int max)
        {
            var diskPtr = 0;
            while (diskPtr <= max)
            {
                FindEmptySpaceStart(data, ref diskPtr, max);
                var start = diskPtr;
                FindEnd(data, ref diskPtr);
                var end = diskPtr;
                if(end - start >= size)
                {
                    diskPtr = start;
                    break;
                }
                else
                {
                    diskPtr++;
                }
            }

            return diskPtr;
        }

        private static void FindEmptySpaceStart(List<int?> data, ref int diskPtr, int max)
        {
            while (diskPtr <= max && data[diskPtr] != null)
            {
                diskPtr++;
            }
        }

        private static void FindEnd(List<int?> data, ref int diskPtr)
        {
            var fileId = data[diskPtr];
            while (diskPtr < data.Count && data[diskPtr] == fileId)
            {
                diskPtr++;
            }
        }

        private static void FindNextFile(List<int?> data, ref int diskPtr)
        {
            while (diskPtr >= 0 && data[diskPtr] == null)
            {
                diskPtr--;
            }
        }

        private static void FindFileStart(List<int?> data, ref int diskPtr)
        {
            var fileId = data[diskPtr];
            while (diskPtr > 0 && data[diskPtr-1] == fileId)
            {
                diskPtr--;
            }
        }

        private static long CalculateChecksum(List<int?> data)
        {
            var checksum = 0L;
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i] != null)
                {
                    checksum += Math.BigMul(i, data[i]!.Value);
                }
            }
            return checksum;
        }
    }
}
