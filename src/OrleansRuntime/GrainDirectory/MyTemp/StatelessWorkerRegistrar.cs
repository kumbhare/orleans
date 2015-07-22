﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.GrainDirectory;

namespace Orleans.Runtime.GrainDirectory.MyTemp
{
    internal class StatelessWorkerRegistrar : GrainRegistrarBase
    {
        public StatelessWorkerRegistrar(LocalGrainDirectory router) : base(router)
        {
            
        }

        public override async Task<Tuple<ActivationAddress, int>> RegisterAsync(ActivationAddress address)
        {                                   
            Router.RegistrationsLocal.Increment();

            // Assume I am the owner, store the new activation locally
            var eTag = Router.DirectoryPartition.AddActivation(address.Grain, address.Activation, address.Silo);
            
            return Tuple.Create(address, eTag);
        }
    }
}