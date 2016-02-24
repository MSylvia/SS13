// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Teleporter : Obj_Item_MechaParts_MechaEquipment {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "bluespace=10";
			this.equip_cooldown = 150;
			this.energy_drain = 1000;
			this.range = 2;
			this.icon_state = "mecha_teleport";
		}

		public Obj_Item_MechaParts_MechaEquipment_Teleporter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: other_tools.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile | InputType.Zone )]
		public override bool f_action( dynamic target = null ) {
			dynamic T = null;

			
			if ( !this.action_checks( target ) || this.loc.z == 2 ) {
				return false;
			}
			T = GlobalFuncs.get_turf( target );

			if ( Lang13.Bool( T ) ) {
				GlobalFuncs.do_teleport( this.chassis, T, 4 );
				return true;
			}
			return false;
		}

	}

}