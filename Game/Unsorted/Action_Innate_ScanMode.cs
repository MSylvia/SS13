// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_ScanMode : Action_Innate {

		public int devices = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Toggle Research Scanner";
			this.button_icon_state = "scan_mode";
			this.check_flags = 11;
		}

		public Action_Innate_ScanMode ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: action.dm
		public override void Remove( dynamic T = null ) {
			this.owner.research_scanner = false;
			this.active = false;
			base.Remove( (object)(T) );
			return;
		}

		// Function from file: action.dm
		public override bool CheckRemoval( dynamic user = null ) {
			
			if ( this.devices != 0 ) {
				return false;
			}
			return true;
		}

		// Function from file: action.dm
		public override void Grant( dynamic T = null ) {
			base.Grant( (object)(T) );
			return;
		}

		// Function from file: action.dm
		public override void Deactivate(  ) {
			this.active = false;
			this.owner.research_scanner = false;
			this.owner.WriteMsg( "<span class='notice'>Research analyzer deactivated.</span>" );
			return;
		}

		// Function from file: action.dm
		public override void Activate( int? forced_state = null ) {
			this.active = true;
			this.owner.research_scanner = true;
			this.owner.WriteMsg( "<span class='notice'>Research analyzer is now active.</span>" );
			return;
		}

	}

}