// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Gun_Nuclear : Obj_Item_Weapon_Gun_Energy_Gun {

		public double fail_tick = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "nucgun";
			this.origin_tech = "combat=3;materials=5;powerstorage=3";
			this.charge_delay = 5;
			this.can_charge = false;
			this.ammo_x_offset = 1;
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Electrode), typeof(Obj_Item_AmmoCasing_Energy_Laser), typeof(Obj_Item_AmmoCasing_Energy_Disabler) });
			this.selfcharge = true;
			this.icon_state = "nucgun";
		}

		public Obj_Item_Weapon_Gun_Energy_Gun_Nuclear ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: nuclear.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );

			if ( this.crit_fail ) {
				this.overlays.Add( "" + this.icon_state + "_fail_3" );
			} else {
				
				dynamic _a = this.fail_tick; // Was a switch-case, sorry for the mess.
				if ( 1<=_a&&_a<=150 ) {
					this.overlays.Add( "" + this.icon_state + "_fail_1" );
				} else if ( 151<=_a&&_a<=Double.PositiveInfinity ) {
					this.overlays.Add( "" + this.icon_state + "_fail_2" );
				} else if ( _a==0 ) {
					this.overlays.Add( "" + this.icon_state + "_fail_0" );
				}
			}
			return false;
		}

		// Function from file: nuclear.dm
		public override double emp_act( int severity = 0 ) {
			base.emp_act( severity );
			this.reliability = Num13.MaxInt( ((int)( this.reliability - Num13.Floor( 15 / severity ) )), 0 );
			return 0;
		}

		// Function from file: nuclear.dm
		public void failcheck(  ) {
			Ent_Static M = null;

			
			if ( !Rand13.PercentChance( ((int)( this.reliability )) ) && this.loc is Mob_Living ) {
				M = this.loc;

				dynamic _a = this.fail_tick; // Was a switch-case, sorry for the mess.
				if ( 0<=_a&&_a<=200 ) {
					this.fail_tick += ( 100 - this.reliability ) * 2;
					M.rad_act( 40 );
					((dynamic)M).WriteMsg( "<span class='userdanger'>Your " + this.name + " feels warmer.</span>" );
				} else if ( 201<=_a&&_a<=Double.PositiveInfinity ) {
					GlobalVars.SSobj.processing.Remove( this );
					M.rad_act( 80 );
					this.crit_fail = true;
					((dynamic)M).WriteMsg( "<span class='userdanger'>Your " + this.name + "'s reactor overloads!</span>" );
				}
			}
			return;
		}

		// Function from file: nuclear.dm
		public override void shoot_live_shot( dynamic user = null, bool? pointblank = null, dynamic pbtarget = null, bool? message = null ) {
			this.failcheck();
			this.update_icon();
			base.shoot_live_shot( (object)(user), pointblank, (object)(pbtarget), message );
			return;
		}

		// Function from file: nuclear.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.fail_tick > 0 ) {
				this.fail_tick--;
			}
			base.process( (object)(seconds) );
			return null;
		}

	}

}