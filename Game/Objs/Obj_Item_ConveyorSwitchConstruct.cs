// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_ConveyorSwitchConstruct : Obj_Item {

		public dynamic id = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 4;
			this.icon = "icons/obj/recycling.dmi";
			this.icon_state = "switch-off";
		}

		// Function from file: conveyor2.dm
		public Obj_Item_ConveyorSwitchConstruct ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.id = Rand13.Float();
			return;
		}

		// Function from file: conveyor2.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			bool found = false;
			Obj_Machinery_Conveyor C = null;
			Obj_Machinery_ConveyorSwitch NC = null;

			
			if ( !( proximity_flag == true ) || Lang13.Bool( user.stat ) || !( target is Tile_Simulated_Floor ) || target is Zone_Shuttle ) {
				return false;
			}
			found = false;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( null, null ), typeof(Obj_Machinery_Conveyor) )) {
				C = _a;
				

				if ( C.id == this.id ) {
					found = true;
					break;
				}
			}

			if ( !found ) {
				user.WriteMsg( new Txt().icon( this ).str( "<span class=notice>The conveyor switch did not detect any linked conveyor belts in range.</span>" ).ToString() );
				return false;
			}
			NC = new Obj_Machinery_ConveyorSwitch( target, this.id );
			this.transfer_fingerprints_to( NC );
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}