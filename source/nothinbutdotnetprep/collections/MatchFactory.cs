using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class MatchFactory
    {
        public MatchFactory()
        {
            
        }

        public Condition<Movie> equal_to(ProductionStudio ps)
        {
            return (x => x.production_studio == ps);
        }

        public Condition<Movie> equal_to_any(params ProductionStudio[] pss)
        {
            return (x =>
                        {
                            bool retval = false; 
                            foreach (ProductionStudio ps in pss)
                                retval = retval || x.production_studio == ps;
                            return retval;
                        });
        }

        public Condition<Movie> equal_to(Genre g)
        {
            return (x => x.genre == g);
        }
    }
}
