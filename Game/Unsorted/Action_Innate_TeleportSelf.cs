// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_TeleportSelf : Action_Innate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Send Self";
			this.button_icon_state = "beam_down";
		}

		public Action_Innate_TeleportSelf ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: camera.dm
		public override void Activate( int? forced_state = null ) {
			dynamic C = null;
			Obj remote_eye = null;
			dynamic P = null;

			
			if ( !Lang13.Bool( this.target ) || !( this.owner is Mob_Living_Carbon ) ) {
				return;
			}
			C = this.owner;
			remote_eye = C.remote_control;
			P = this.target;

			if ( GlobalVars.cameranet.checkTurfVis( remote_eye.loc ) ) {
				((Obj_Machinery_Abductor_Pad)P).MobToLoc( remote_eye.loc, C );
			}
			return;
		}

	}

}