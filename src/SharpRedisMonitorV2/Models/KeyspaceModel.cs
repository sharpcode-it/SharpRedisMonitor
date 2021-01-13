// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.Collections.Generic;

namespace SharpRedisMonitorV2.Models
{
    public class KeyspaceModel
    {
        public List<DatabaseModel> DatabaseList { get; set; }
        public string Hits { get; set; }
        public string Misses { get; set; }
        public string Expired { get; set; }

        public KeyspaceModel()
        {
            DatabaseList = new List<DatabaseModel>();
        }
    }
}
