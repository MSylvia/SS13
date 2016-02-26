// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy : Obj_Item_Weapon_Gun {

		public dynamic power_supply = null;
		public dynamic cell_type = typeof(Obj_Item_Weapon_StockParts_Cell);
		public int modifystate = 0;
		public ByTable ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy) });
		public int select = 1;
		public bool can_charge = true;
		public bool shaded_charge = false;
		public bool selfcharge = false;
		public int charge_tick = 0;
		public int charge_delay = 4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_x_offset = 2;
			this.icon = "icons/obj/guns/energy.dmi";
			this.icon_state = "energy";
		}

		// Function from file: energy.dm
		public Obj_Item_Weapon_Gun_Energy ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic shot = null;
			int? i = null;
			dynamic shottype = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( this.cell_type ) ) {
				this.power_supply = Lang13.Call( this.cell_type, this );
			} else {
				this.power_supply = new Obj_Item_Weapon_StockParts_Cell( this );
			}
			((Obj_Item_Weapon_StockParts_Cell)this.power_supply).give( this.power_supply.maxcharge );
			i = null;
			i = 1;

			while (( i ??0) <= this.ammo_type.len) {
				shottype = this.ammo_type[i];
				shot = Lang13.Call( shottype, this );
				this.ammo_type[i] = shot;
				i++;
			}
			shot = this.ammo_type[this.select];
			this.fire_sound = shot.fire_sound;
			this.fire_delay = shot.delay;

			if ( this.selfcharge ) {
				GlobalVars.SSobj.processing.Or( this );
			}
			this.update_icon();
			return;
		}

		// Function from file: energy.dm
		public override void on_varedit( dynamic modified_var = null ) {
			
			if ( modified_var == "selfcharge" ) {
				
				if ( this.selfcharge ) {
					GlobalVars.SSobj.processing.Or( this );
				} else {
					GlobalVars.SSobj.processing.Remove( this );
				}
			}
			return;
		}

		// Function from file: energy.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			
			if ( Lang13.Bool( this.can_shoot() ) ) {
				user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is putting the barrel of the " ).item( this.name ).str( " in " ).his_her_its_their().str( " mouth.  It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
				Task13.Sleep( 25 );

				if ( user.l_hand == this || user.r_hand == this ) {
					user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " melts " ).his_her_its_their().str( " face off with the " ).item( this.name ).str( "!</span>" ).ToString() );
					GlobalFuncs.playsound( this.loc, this.fire_sound, 50, 1, -1 );
					shot = this.ammo_type[this.select];
					((Obj_Item_Weapon_StockParts_Cell)this.power_supply).use( shot.e_cost );
					this.update_icon();
					return 2;
				} else {
					user.visible_message( "<span class='suicide'>" + user + " panics and starts choking to death!</span>" );
					return 8;
				}
			} else {
				user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is pretending to blow " ).his_her_its_their().str( " brains out with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide!</b></span>" ).ToString() );
				GlobalFuncs.playsound( this.loc, "sound/weapons/empty.ogg", 50, 1, -1 );
				return 8;
			}
			return 0;
		}

		// Function from file: energy.dm
		public override void ui_action_click(  ) {
			this.toggle_gunlight();
			return;
		}

		// Function from file: energy.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			int ratio = 0;
			Obj_Item_AmmoCasing_Energy shot = null;
			string iconState = null;
			string itemState = null;
			int? i = null;
			string iconF = null;

			this.overlays.Cut();
			ratio = GlobalFuncs.Ceiling( this.power_supply.charge / this.power_supply.maxcharge * 4 );
			shot = this.ammo_type[this.select];
			iconState = "" + this.icon_state + "_charge";
			itemState = null;

			if ( !Lang13.Bool( Lang13.Initial( this, "item_state" ) ) ) {
				itemState = this.icon_state;
			}

			if ( this.modifystate != 0 ) {
				this.overlays.Add( "" + this.icon_state + "_" + shot.select_name );
				iconState += "_" + shot.select_name;

				if ( Lang13.Bool( itemState ) ) {
					itemState += "" + shot.select_name;
				}
			}

			if ( Convert.ToDouble( this.power_supply.charge ) < ( shot.e_cost ??0) ) {
				this.overlays.Add( "" + this.icon_state + "_empty" );
			} else if ( !this.shaded_charge ) {
				i = null;
				i = ratio;

				while (( i ??0) >= 1) {
					this.overlays.Add( new Image( this.icon, null, iconState, null, null, this.ammo_x_offset * ( ( i ??0) - 1 ) ) );
					i--;
				}
			} else {
				this.overlays.Add( new Image( this.icon, null, "" + this.icon_state + "_charge" + ratio ) );
			}

			if ( Lang13.Bool( this.F ) ) {
				iconF = "flight";

				if ( Lang13.Bool( this.F.on ) ) {
					iconF = "flight_on";
				}
				this.overlays.Add( new Image( this.icon, null, iconF, null, null, this.flight_x_offset, this.flight_y_offset ) );
			}

			if ( Lang13.Bool( itemState ) ) {
				itemState += "" + ratio;
				this.item_state = itemState;
			}
			return false;
		}

		// Function from file: energy.dm
		public void robocharge(  ) {
			Ent_Static R = null;
			Obj_Item_AmmoCasing_Energy shot = null;

			
			if ( this.loc is Mob_Living_Silicon_Robot ) {
				R = this.loc;

				if ( R != null && Lang13.Bool( ((dynamic)R).cell ) ) {
					shot = this.ammo_type[this.select];

					if ( ((Obj_Item_Weapon_StockParts_Cell)((dynamic)R).cell).use( shot.e_cost ) ) {
						((Obj_Item_Weapon_StockParts_Cell)this.power_supply).give( shot.e_cost );
					}
				}
			}
			return;
		}

		// Function from file: energy.dm
		public void select_fire( dynamic user = null ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			this.select++;

			if ( this.select > this.ammo_type.len ) {
				this.select = 1;
			}
			shot = this.ammo_type[this.select];
			this.fire_sound = shot.fire_sound;
			this.fire_delay = shot.delay;

			if ( Lang13.Bool( shot.select_name ) ) {
				user.WriteMsg( "<span class='notice'>" + this + " is now set to " + shot.select_name + ".</span>" );
			}
			this.update_icon();
			return;
		}

		// Function from file: energy.dm
		public override bool process_chamber( bool? eject_casing = null, bool? empty_chamber = null ) {
			dynamic shot = null;

			
			if ( Lang13.Bool( this.chambered ) && !Lang13.Bool( this.chambered.BB ) ) {
				shot = this.chambered;
				this.power_supply.use( shot.e_cost );
			}
			this.chambered = null;
			return false;
		}

		// Function from file: energy.dm
		public override void newshot(  ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			
			if ( !( this.ammo_type != null ) || !Lang13.Bool( this.power_supply ) ) {
				return;
			}
			shot = this.ammo_type[this.select];

			if ( Convert.ToDouble( this.power_supply.charge ) >= ( shot.e_cost ??0) ) {
				this.chambered = shot;
				this.chambered.newshot();
			}
			return;
		}

		// Function from file: energy.dm
		public override dynamic can_shoot(  ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			shot = this.ammo_type[this.select];
			return Convert.ToDouble( this.power_supply.charge ) >= ( shot.e_cost ??0);
		}

		// Function from file: energy.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			this.newshot();
			base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			return false;
		}

		// Function from file: energy.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.ammo_type.len > 1 ) {
				this.select_fire( user );
				this.update_icon();
			}
			return null;
		}

		// Function from file: energy.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.selfcharge ) {
				this.charge_tick++;

				if ( this.charge_tick < this.charge_delay ) {
					return null;
				}
				this.charge_tick = 0;

				if ( !Lang13.Bool( this.power_supply ) ) {
					return null;
				}
				((Obj_Item_Weapon_StockParts_Cell)this.power_supply).give( 100 );
				this.update_icon();
			}
			return null;
		}

		// Function from file: energy.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return base.Destroy();
		}

		// Function from file: energy.dm
		public override double emp_act( int severity = 0 ) {
			((Obj_Item_Weapon_StockParts_Cell)this.power_supply).use( Num13.Floor( Convert.ToDouble( this.power_supply.charge / severity ) ) );
			this.update_icon();
			return 0;
		}

	}

}