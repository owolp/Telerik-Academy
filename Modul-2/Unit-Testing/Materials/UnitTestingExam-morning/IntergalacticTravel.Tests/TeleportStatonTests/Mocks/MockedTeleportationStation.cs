using IntergalacticTravel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStatonTests.Mocks
{
    class MockedTeleportationStation : TeleportStation
    {
        public MockedTeleportationStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) 
            : base(owner, galacticMap, location)
        {
        }

        public IResources Resources 
        {
            get
            {
                return base.resources;
            }
        }

        public IBusinessOwner GetOwner
        {
            get
            {
                return base.owner;
            }
        }

        public IEnumerable<IPath> GetMap
        {
            get
            {
                return base.galacticMap;
            }
        }

        public ILocation GetLocation
        {
            get
            {
                return base.location;
            }
        }
    }
}
