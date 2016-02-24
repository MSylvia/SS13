// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Medical : Obj_Item_MechaParts_MechaEquipment {

		// Function from file: medical_tools.dm
		public Obj_Item_MechaParts_MechaEquipment_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: medical_tools.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( !( this.chassis != null ) ) {
				GlobalVars.SSobj.processing.Remove( this );
				return 1;
			}
			return null;
		}

		// Function from file: medical_tools.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return base.Destroy();
		}

		// Function from file: medical_tools.dm
		public override void attach( Obj_Mecha M = null ) {
			base.attach( M );
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: medical_tools.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) && M is Obj_Mecha_Medical ) {
				return true;
			}
			return false;
		}

	}

}