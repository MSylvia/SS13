// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Meson_Engine_Tray : Obj_Item_Clothing_Glasses_Meson_Engine {

		public bool on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_button_name = "Toggle Scanner Power";
			this.mode = true;
			this.range = 2;
			this.icon_state = "trayson-tray_off";
		}

		public Obj_Item_Clothing_Glasses_Meson_Engine_Tray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: engine_goggles.dm
		public override int t_ray_on(  ) {
			return this.on && base.t_ray_on() != 0 ?1:0;
		}

		// Function from file: engine_goggles.dm
		public override void ui_action_click(  ) {
			this.on = !this.on;

			if ( this.on ) {
				GlobalVars.SSobj.processing.Or( this );
				((dynamic)this.loc).WriteMsg( "<span class='notice'>You turn the goggles on.</span>" );
			} else {
				GlobalVars.SSobj.processing.Remove( this );
				((dynamic)this.loc).WriteMsg( "<span class='notice'>You turn the goggles off.</span>" );
				this.invis_update();
			}
			this.update_icon();
			return;
		}

		// Function from file: engine_goggles.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Ent_Static user = null;

			this.icon_state = "trayson-tray" + ( this.on ? "" : "_off" );

			if ( this.loc is Mob_Living_Carbon_Human ) {
				user = this.loc;

				if ( ((dynamic)user).glasses == this ) {
					((dynamic)user).update_inv_glasses();
				}
			}
			return false;
		}

		// Function from file: engine_goggles.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( !this.on ) {
				return null;
			}
			base.process( (object)(seconds) );
			return null;
		}

	}

}