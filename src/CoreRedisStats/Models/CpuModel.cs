// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace CoreRedisStats.Models
{
    public class CpuModel
    {
        public double ServerLoad { get; set; }
        public string UsedCpuSys { get; set; }
        public string UsedCpuUser { get; set; }
    }
}
