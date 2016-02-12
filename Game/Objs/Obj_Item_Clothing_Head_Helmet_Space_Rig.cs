// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Rig : Obj_Item_Clothing_Head_Helmet_Space {

		public int brightness_on = 4;
		public bool on = false;
		public bool no_light = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "eng_helm";
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 5 ).Set( "laser", 20 ).Set( "energy", 5 ).Set( "bomb", 35 ).Set( "bio", 100 ).Set( "rad", 80 );
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Device_Flashlight) });
			this.light_power = 1.7;
			this._color = "engineering";
			this.action_button_name = "Toggle Helmet Light";
			this.max_heat_protection_temperature = 5000;
			this.pressure_resistance = 20265;
			this.eyeprot = 3;
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.icon_state = "rig0-engineering";
		}

		// Function from file: rig.dm
		public Obj_Item_Clothing_Head_Helmet_Space_Rig ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.check_light();
			this.update_brightness();
			this.update_icon();
			return;
		}

		// Function from file: rig.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.no_light ) {
				return null;
			}
			this.on = !this.on;
			this.update_icon();
			((Mob)user).update_inv_head();

			if ( this.on ) {
				this.set_light( this.brightness_on );
			} else {
				this.set_light( 0 );
			}
			((Mob)user).update_inv_head();
			return null;
		}

		// Function from file: rig.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "rig" + this.on + "-" + this._color;
			return null;
		}

		// Function from file: rig.dm
		public void update_brightness(  ) {
			
			if ( this.on ) {
				this.set_light( this.brightness_on );
			} else {
				this.set_light( 0 );
			}
			this.update_icon();
			return;
		}

		// Function from file: rig.dm
		public void check_light(  ) {
			
			if ( this.no_light ) {
				
				if ( this.on ) {
					this.on = false;
					this.update_brightness();
				}
				this.action_button_name = null;
			} else {
				this.action_button_name = Lang13.Initial( this, "action_button_name" );
			}
			return;
		}

		// Function from file: rig.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( !this.no_light ) {
				GlobalFuncs.to_chat( user, "The helmet is mounted with an Internal Lighting System, it is " + ( this.on ? "" : "un" ) + "lit." );
			}
			return null;
		}

	}

}