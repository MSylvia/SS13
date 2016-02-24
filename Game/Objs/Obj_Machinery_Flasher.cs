// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Flasher : Obj_Machinery {

		public dynamic bulb = null;
		public string id = null;
		public int range = 2;
		public int last_flash = 0;
		public int strength = 5;
		public string base_state = "mflash";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon_state = "mflash1";
		}

		// Function from file: flasher.dm
		public Obj_Machinery_Flasher ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.bulb = new Obj_Item_Device_Assembly_Flash_Handheld( this );
			return;
		}

		// Function from file: flasher.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return 0;
			}

			if ( Lang13.Bool( this.bulb ) && Rand13.PercentChance( ((int)( 75 / severity )) ) ) {
				this.flash();
				((Obj_Item_Device_Assembly_Flash)this.bulb).burn_out();
				this.power_change();
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: flasher.dm
		public bool flash(  ) {
			Mob_Living L = null;

			
			if ( !Lang13.Bool( this.powered() ) || !Lang13.Bool( this.bulb ) ) {
				return false;
			}

			if ( this.bulb.crit_fail || this.last_flash != 0 && Game13.time < this.last_flash + 150 ) {
				return false;
			}

			if ( !((Obj_Item_Device_Assembly_Flash)this.bulb).flash_recharge( 30 ) ) {
				this.power_change();
				return false;
			}
			this.bulb.times_used++;
			GlobalFuncs.playsound( this.loc, "sound/weapons/flash.ogg", 100, 1 );
			Icon13.Flick( "" + this.base_state + "_flash", this );
			this.last_flash = Game13.time;
			this.f_use_power( 1000 );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ), typeof(Mob_Living) )) {
				L = _a;
				

				if ( Map13.GetDistance( this, L ) > this.range ) {
					continue;
				}

				if ( L.flash_eyes( null, null, true ) ) {
					L.Weaken( this.strength );

					if ( L.weakeyes ) {
						L.Weaken( this.strength * 1.5 );
						L.visible_message( "<span class='disarm'><b>" + L + "</b> gasps and shields their eyes!</span>" );
					}
				}
			}
			return true;
		}

		// Function from file: flasher.dm
		public override dynamic attack_ai( dynamic user = null ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				return this.flash();
			} else {
				return null;
			}
		}

		// Function from file: flasher.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Wirecutters ) {
				
				if ( Lang13.Bool( this.bulb ) ) {
					((Ent_Static)user).visible_message( "" + user + " begins to disconnect " + this + "'s flashbulb.", "<span class='notice'>You begin to disconnect " + this + "'s flashbulb...</span>" );
					GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );

					if ( GlobalFuncs.do_after( user, 30 / A.toolspeed, null, this ) && Lang13.Bool( this.bulb ) ) {
						((Ent_Static)user).visible_message( "" + user + " has disconnected " + this + "'s flashbulb!", "<span class='notice'>You disconnect " + this + "'s flashbulb.</span>" );
						this.bulb.loc = this.loc;
						this.bulb = null;
						this.power_change();
					}
				}
			} else if ( A is Obj_Item_Device_Assembly_Flash_Handheld ) {
				
				if ( !Lang13.Bool( this.bulb ) ) {
					
					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					((Ent_Static)user).visible_message( "" + user + " installs " + A + " into " + this + ".", "<span class='notice'>You install " + A + " into " + this + ".</span>" );
					A.loc = this;
					this.bulb = A;
					this.power_change();
				} else {
					user.WriteMsg( "<span class='warning'>A flashbulb is already installed in " + this + "!</span>" );
				}
			}
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: flasher.dm
		public override void power_change(  ) {
			
			if ( Lang13.Bool( this.powered() ) && Lang13.Bool( this.anchored ) && Lang13.Bool( this.bulb ) ) {
				this.stat &= 65533;

				if ( this.bulb.crit_fail ) {
					this.icon_state = "" + this.base_state + "1-p";
				} else {
					this.icon_state = "" + this.base_state + "1";
				}
			} else {
				this.stat |= 65533;
				this.icon_state = "" + this.base_state + "1-p";
			}
			return;
		}

		// Function from file: flasher.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			GlobalFuncs.remove_from_proximity_list( this, this.range );
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			return false;
		}

	}

}