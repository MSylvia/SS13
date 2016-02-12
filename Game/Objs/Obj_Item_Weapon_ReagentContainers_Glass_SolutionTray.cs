// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_SolutionTray : Obj_Item_Weapon_ReagentContainers_Glass {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$glass", 20 );
			this.amount_per_transfer_from_this = 1;
			this.possible_transfer_amounts = new ByTable(new object [] { 1, 2 });
			this.volume = 2;
			this.icon = "icons/obj/device.dmi";
			this.icon_state = "solution_tray";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_SolutionTray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: chemistry.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string new_label = null;

			
			if ( a is Obj_Item_Weapon_Pen || a is Obj_Item_Device_Flashlight_Pen ) {
				new_label = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "What should the new label be?", "Label solution tray", null, null, null, InputType.Str | InputType.Null ) ), 1, 26 );

				if ( Lang13.Bool( new_label ) && this.Adjacent( b ) && !Lang13.Bool( b.stat ) ) {
					this.name = "solution tray (" + new_label + ")";
					GlobalFuncs.to_chat( b, "<span class='notice'>You write on the label of the solution tray.</span>" );
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: chemistry.dm
		public override dynamic mop_act( Obj_Item_Weapon_Mop M = null, dynamic user = null ) {
			return 1;
		}

	}

}