using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DunGen
{
    /// <summary>
    /// An identifier for marking doorways as a specific type. If you have different doorway sizes, they should
    /// be marked with a different DoorwaySocketType. Add any new types you need to the DoorwaySocketType enum. E.g:
    /// 
    /// Default,
    /// Small,
    /// Large,
    /// MainGate,
    /// 
    /// NOTE: Removing a socket type from this list will result in any doorway using this type falling back to the
    /// "Default" value
    /// 
    /// </summary>
	public enum DoorwaySocketType
	{
        Default,
        Large,
        Vertical,
		Castle_Spec_Curve90,
		Castle_Spec_Curve90corridor,
		Castle_Spec_Curve90Side,
		Castle_Spec_Curve90Side1,
		Castle_Spec_BossPalace1a,
		Castle_Spec_BossPalace1b,
		Castle_Spec_BossPalace2a,
		Castle_Spec_BossPalace2b,
		Castle_Spec_BossPalace2c,
		Castle_Spec_BossPalace2d,
		Castle_Spec_BossPalace3a,
		Castle_Spec_BossPalace3b,
		Castle_Spec_BossPalace2_,
	}

    /// <summary>
    /// A helper class for working with doorway sockets
    /// </summary>
    public static class DoorwaySocket
    {
        /// <summary>
        /// Checks if two doorway sockets match
        /// </summary>
        public static bool IsMatchingSocket(DoorwaySocketType a, DoorwaySocketType b)
        {
			// You can add any custom logic here if you like. For most cases, the default implementation will suffice.
			return a == b;
        }
    }
}
