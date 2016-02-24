// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortaTurret_DefensepylonInternalTurret : Obj_Machinery_PortaTurret {

		public string side = "neutral";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.installation = null;
			this.always_up = true;
			this.use_power = 0;
			this.has_cover = false;
			this.health = 200;
			this.projectile = typeof(Obj_Item_Projectile_Beam_PylonBolt);
			this.eprojectile = typeof(Obj_Item_Projectile_Beam_PylonBolt);
			this.shot_sound = "sound/weapons/emitter2.ogg";
			this.eshot_sound = "sound/weapons/emitter2.ogg";
			this.base_icon_state = "defensepylon";
			this.active_state = "";
			this.off_state = "";
			this.faction = null;
			this.emp_vunerable = false;
			this.icon = "icons/obj/hand_of_god_structures.dmi";
		}

		public Obj_Machinery_PortaTurret_DefensepylonInternalTurret ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: structures.dm
		public override int assess_perp( dynamic perp = null ) {
			bool badtarget = false;

			
			if ( Lang13.Bool( perp.handcuffed ) ) {
				return 0;
			}
			badtarget = false;

			switch ((string)( this.side )) {
				case "blue":
					badtarget = GlobalFuncs.is_handofgod_bluecultist( perp );
					break;
				case "red":
					badtarget = GlobalFuncs.is_handofgod_redcultist( perp );
					break;
				default:
					badtarget = true;
					break;
			}

			if ( badtarget ) {
				return 0;
			}
			return 10;
		}

		// Function from file: structures.dm
		public override dynamic shootAt( dynamic target = null ) {
			dynamic A = null;

			A = base.shootAt( (object)(target) );

			if ( Lang13.Bool( A ) ) {
				A.color = this.side;
			}
			return null;
		}

		// Function from file: structures.dm
		public override void setup(  ) {
			return;
		}

	}

}