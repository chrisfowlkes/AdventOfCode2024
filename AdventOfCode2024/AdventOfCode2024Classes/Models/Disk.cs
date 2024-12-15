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
        /// <returns>Checksum.</returns>
        internal long Compress()
        {
            var data = BuildFileSystem();
            Compress(data);
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
                    //Odd. Use 0.
                    for (int j = 0; j < size; j++)
                    {
                        data.Add(null);
                    }
                }
            }

            return data;
        }

        private static void Compress(List<int?> data)
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

        private static long CalculateChecksum(List<int?> data)
        {
            var checksum = 0L;
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i] != null)
                {
                    checksum += i * data[i]!.Value;
                }
            }
            return checksum;
        }
    }
}
