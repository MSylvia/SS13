// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DroneDispenser : Obj_Machinery {

		public int health = 100;
		public int max_health = 100;
		public string icon_off = "off";
		public string icon_on = "on";
		public string icon_recharging = "recharge";
		public string icon_creating = "make";
		public double metal = 0;
		public double glass = 0;
		public double metal_cost = 1000;
		public double glass_cost = 1000;
		public double power_used = 1000;
		public bool droneMadeRecently = false;
		public int cooldownTime = 1800;
		public Type dispense_type = typeof(Obj_Item_DroneShell);
		public string work_sound = "sound/items/rped.ogg";
		public string create_sound = "sound/items/Deconstruct.ogg";
		public string recharge_sound = "sound/machines/ping.ogg";
		public string begin_create_message = "whirs to life!";
		public string end_create_message = "dispenses a drone shell.";
		public string recharge_message = "pings.";
		public string recharging_text = "It is whirring and clicking. It seems to be recharging.";
		public string break_message = "lets out a tinny alarm before falling dark.";
		public string break_sound = "sound/machines/warning-buzzer.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/machines/droneDispenser.dmi";
			this.icon_state = "on";
		}

		// Function from file: droneDispenser.dm
		public Obj_Machinery_DroneDispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.health = this.max_health;
			GlobalVars.SSmachine.processing.Or( this );
			return;
		}

		// Function from file: droneDispenser.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic stack = null;
			dynamic sheets = null;
			dynamic WT = null;

			
			if ( A is Obj_Item_Stack ) {
				
				if ( !Lang13.Bool( A.materials["$metal"] ) && !Lang13.Bool( A.materials["$glass"] ) ) {
					return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
				}

				if ( !( this.metal_cost != 0 ) && !( this.glass_cost != 0 ) ) {
					user.WriteMsg( "<span class='warning'>There isn't a place to insert " + A + "!</span>" );
					return null;
				}
				stack = 1;
				sheets = A;
				stack = Interface13.Input( user, "How many sheets do you want to add?.", "Drone Dispenser", "" + stack, null, InputType.Num );

				if ( Convert.ToDouble( stack ) <= 0 ) {
					return null;
				}

				if ( !((Mob)user).canUseTopic( this ) ) {
					return null;
				}
				stack = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( stack ), Convert.ToInt32( sheets.max_amount ) ) );
				sheets.use( stack );

				if ( !Lang13.Bool( stack ) ) {
					
					if ( !((Mob)user).unEquip( A ) ) {
						user.WriteMsg( "<span class='warning'>" + A + " is stuck to your hand, you can't get it off!</span>" );
						return null;
					}
					user.drop_item();
					A.loc = this;
				}
				this.metal += Convert.ToDouble( A.materials["$metal"] * stack );
				this.glass += Convert.ToDouble( A.materials["$glass"] * stack );
				user.WriteMsg( "<span class='notice'>You insert " + stack + " sheet" + ( Convert.ToDouble( stack ) > 1 ? "s" : "" ) + " to " + this + ".</span>" );

				if ( Lang13.Bool( A ) && A.loc == this || !Lang13.Bool( stack ) ) {
					GlobalFuncs.qdel( A );
				}
				return null;
			}

			if ( A is Obj_Item_Weapon_Weldingtool && ( this.stat & 1 ) != 0 ) {
				WT = A;

				if ( !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
					return null;
				}

				if ( ( ((Obj_Item_Weapon_Weldingtool)WT).get_fuel() ?1:0) < 1 ) {
					user.WriteMsg( "<span class='warning'>You need more fuel to complete this task!</span>" );
					return null;
				}
				GlobalFuncs.playsound( this, "sound/items/welder.ogg", 50, 1 );
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " begins patching up " + this + " with " + WT + ".</span>", "<span class='notice'>You begin restoring the damage to " + this + "...</span>" );

				if ( !GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
					return null;
				}

				if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 1, user ) ) {
					return null;
				}
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " fixes " + this + "!</span>", "<span class='notice'>You restore " + this + " to operation.</span>" );
				this.stat -= 1;
				this.icon_state = this.icon_on;
				return null;
			}

			if ( Lang13.Bool( A.force ) && this.stat != 1 ) {
				((Ent_Static)user).visible_message( "<span class='danger'>" + user + " hits " + this + " with " + A + "!</span>", "<span class='warning'>You hit " + this + " with " + A + "!</span>" );
				GlobalFuncs.playsound( this, A.hitsound, 50, 1 );
				this.health = Num13.MaxInt( 0, Num13.MinInt( ((int)( this.health - Convert.ToDouble( A.force ) )), this.max_health ) );

				if ( this.health <= 0 ) {
					
					if ( Lang13.Bool( this.break_message ) ) {
						this.audible_message( "<span class='warning'>" + this + " " + this.break_message + "</span>" );
					}

					if ( Lang13.Bool( this.break_sound ) ) {
						GlobalFuncs.playsound( this, this.break_sound, 50, 1 );
					}
					this.stat = 1;
					this.icon_state = this.icon_off;
				}
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: droneDispenser.dm
		public override int? process( dynamic seconds = null ) {
			base.process( (object)(seconds) );

			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				return null;
			}

			if ( this.metal_cost != 0 && this.glass_cost != 0 && ( this.metal < this.metal_cost || this.glass < this.glass_cost ) ) {
				return null;
			}

			if ( this.droneMadeRecently ) {
				this.icon_state = this.icon_recharging;
				return null;
			}
			this.droneMadeRecently = true;

			if ( Lang13.Bool( this.begin_create_message ) ) {
				this.visible_message( "<span class='notice'>" + this + " " + this.begin_create_message + "</span>" );
			}

			if ( Lang13.Bool( this.work_sound ) ) {
				GlobalFuncs.playsound( this, this.work_sound, 50, 1 );
			}
			this.icon_state = this.icon_creating;
			Task13.Sleep( 30 );
			this.icon_state = this.icon_on;
			this.metal -= this.metal_cost;
			this.glass -= this.glass_cost;

			if ( this.metal < 0 ) {
				this.metal = 0;
			}

			if ( this.glass < 0 ) {
				this.glass = 0;
			}

			if ( this.power_used != 0 ) {
				this.f_use_power( this.power_used );
			}
			Lang13.Call( this.dispense_type, this.loc );

			if ( Lang13.Bool( this.create_sound ) ) {
				GlobalFuncs.playsound( this, this.create_sound, 50, 1 );
			}

			if ( Lang13.Bool( this.end_create_message ) ) {
				this.visible_message( "<span class='notice'>" + this + " " + this.end_create_message + "</span>" );
			}
			this.icon_state = this.icon_recharging;
			Task13.Sleep( this.cooldownTime );

			if ( this.stat != 1 ) {
				this.icon_state = this.icon_on;
			} else {
				this.icon_state = this.icon_off;
			}
			this.droneMadeRecently = false;

			if ( Lang13.Bool( this.recharge_sound ) ) {
				GlobalFuncs.playsound( this, this.recharge_sound, 50, 1 );
			}

			if ( Lang13.Bool( this.recharge_message ) ) {
				this.visible_message( "<span class='notice'>" + this + " " + this.recharge_message + "</span>" );
			}
			return null;
		}

		// Function from file: droneDispenser.dm
		public override void power_change(  ) {
			base.power_change();

			if ( ( this.stat & 1 ) != 0 ) {
				return;
			} else if ( Lang13.Bool( this.powered() ) ) {
				this.stat &= 65533;
			} else {
				this.icon_state = "off";
				this.stat |= 2;
			}
			return;
		}

		// Function from file: droneDispenser.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.droneMadeRecently && !( this.stat != 0 ) && Lang13.Bool( this.recharging_text ) ) {
				user.WriteMsg( "<span class='warning'>" + this.recharging_text + "</span>" );
			}

			if ( ( this.stat & 1 ) != 0 ) {
				user.WriteMsg( "<span class='warning'>" + this + " is smoking and steadily buzzing. It seems to be broken.</span>" );
			}

			if ( this.metal_cost != 0 ) {
				user.WriteMsg( "<span class='notice'>It has " + this.metal + " units of metal stored.</span>" );
			}

			if ( this.glass_cost != 0 ) {
				user.WriteMsg( "<span class='notice'>It has " + this.glass + " units of glass stored.</span>" );
			}
			return 0;
		}

		// Function from file: droneDispenser.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSmachine.processing.Remove( this );
			return base.Destroy();
		}

	}

}