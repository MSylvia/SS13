// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Bot : Obj_Machinery {

		public Obj_Item_Weapon_Card_Id botcard = null;
		public bool on = true;
		public double health = 0;
		public double maxhealth = 0;
		public double fire_dam_coeff = 1;
		public double brute_dam_coeff = 1;
		public bool open = false;
		public bool locked = true;
		public int bot_type = 0;
		public string declare_message = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 3;
			this.use_power = 0;
			this.icon = "icons/obj/aibots.dmi";
			this.layer = 4;
		}

		// Function from file: bots.dm
		public Obj_Machinery_Bot ( dynamic loc = null ) : base( (object)(loc) ) {
			Event_Ionstorm I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.events, typeof(Event_Ionstorm) )) {
				I = _a;
				

				if ( I is Event_Ionstorm && I.active ) {
					I.bots.Add( this );
				}
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: bots.dm
		public override dynamic cultify(  ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			} else {
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: bots.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			this.attack_hand( user );
			return null;
		}

		// Function from file: bots.dm
		public override dynamic emp_act( int severity = 0 ) {
			bool was_on = false;
			Obj_Effect_Overlay pulse2 = null;

			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			}
			was_on = this.on;
			this.stat |= 16;
			pulse2 = new Obj_Effect_Overlay( this.loc );
			pulse2.icon = "icons/effects/effects.dmi";
			pulse2.icon_state = "empdisable";
			pulse2.name = "emp sparks";
			pulse2.anchored = 1;
			pulse2.dir = Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) );
			Task13.Schedule( 10, (Task13.Closure)(() => {
				GlobalFuncs.qdel( pulse2 );
				return;
			}));

			if ( this.on ) {
				this.turn_off();
			}
			Task13.Schedule( severity * 300, (Task13.Closure)(() => {
				this.stat &= 65519;

				if ( was_on ) {
					this.turn_on();
				}
				return;
			}));
			return null;
		}

		// Function from file: bots.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return false;
			}

			switch ((int?)( severity )) {
				case 1:
					this.explode();
					return false;
					break;
				case 2:
					this.health -= Rand13.Int( 5, 10 ) * this.fire_dam_coeff;
					this.health -= Rand13.Int( 10, 20 ) * this.brute_dam_coeff;
					this.healthcheck();
					return false;
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= Rand13.Int( 1, 5 ) * this.fire_dam_coeff;
						this.health -= Rand13.Int( 1, 5 ) * this.brute_dam_coeff;
						this.healthcheck();
						return false;
					}
					break;
			}
			return false;
		}

		// Function from file: bots.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return false;
			}
			this.health -= Rand13.Int( 20, 40 ) * this.fire_dam_coeff;
			this.healthcheck();
			return false;
		}

		// Function from file: bots.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			}
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.healthcheck();
			return null;
		}

		// Function from file: bots.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				
				if ( !this.locked ) {
					this.open = !this.open;
					GlobalFuncs.to_chat( b, "<span class='notice'>Maintenance panel is now " + ( this.open ? "opened" : "closed" ) + ".</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Weldingtool ) {
				
				if ( this.health < this.maxhealth ) {
					
					if ( this.open ) {
						this.health = Num13.MinInt( ((int)( this.maxhealth )), ((int)( this.health + 10 )) );
						((Ent_Static)b).visible_message( "<span class='danger'>" + b + " repairs " + this + "!</span>", "<span class='notice'>You repair " + this + "!</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>Unable to repair with the maintenance panel closed.</span>" );
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " does not need a repair.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Card_Emag && this.emagged < 2 ) {
				this.Emag( b );
			} else if ( GlobalFuncs.hasvar( a, "force" ) && GlobalFuncs.hasvar( a, "damtype" ) ) {
				
				dynamic _a = a.damtype; // Was a switch-case, sorry for the mess.
				if ( _a=="fire" ) {
					this.health -= Convert.ToDouble( a.force * this.fire_dam_coeff );
				} else if ( _a=="brute" ) {
					this.health -= Convert.ToDouble( a.force * this.brute_dam_coeff );
				}
				base.attackby( (object)(a), (object)(b), (object)(c) );
				this.healthcheck();
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: bots.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			Game_Data O = null;

			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			}

			if ( Lang13.Bool( ((dynamic)user).melee_damage_upper ) == false ) {
				return null;
			}
			this.health -= Convert.ToDouble( ((dynamic)user).melee_damage_upper );
			this.visible_message( "<span class='danger'>" + user + " has " + ((dynamic)user).attacktext + " " + this + "!</span>" );
			GlobalFuncs.add_logs( user, this, "attacked", false );

			if ( Rand13.PercentChance( 10 ) ) {
				O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Oil), this.loc );
				((dynamic)O).New( ((dynamic)O).loc );
			}
			this.healthcheck();
			return null;
		}

		// Function from file: bots.dm
		public override dynamic attack_alien( Mob user = null ) {
			Game_Data O = null;

			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return null;
			}
			this.health -= Rand13.Int( 15, 30 ) * this.brute_dam_coeff;
			this.visible_message( "<span class='danger'>" + user + " has slashed " + this + "!</span>" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/slice.ogg", 25, 1, -1 );

			if ( Rand13.PercentChance( 10 ) ) {
				O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Oil), this.loc );
				((dynamic)O).New( ((dynamic)O).loc );
			}
			this.healthcheck();
			return null;
		}

		// Function from file: bots.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.health < this.maxhealth ) {
				
				if ( this.health > this.maxhealth / 3 ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>" + this + "'s parts look loose.</span>" );
				} else {
					GlobalFuncs.to_chat( user, "<span class='danger'>" + this + "'s parts look very loose!</span>" );
				}
			}
			return null;
		}

		// Function from file: bots.dm
		public virtual void declare(  ) {
			ByTable hud_user_list = null;
			dynamic myturf = null;
			dynamic huduser = null;
			dynamic mobturf = null;

			hud_user_list = new ByTable();

			switch ((int)( this.bot_type )) {
				case 1:
					hud_user_list = GlobalVars.sec_hud_users;
					break;
				case 5:
					hud_user_list = GlobalVars.med_hud_users;
					break;
			}
			myturf = GlobalFuncs.get_turf( this );

			foreach (dynamic _b in Lang13.Enumerate( hud_user_list )) {
				huduser = _b;
				
				mobturf = GlobalFuncs.get_turf( huduser );

				if ( mobturf.z == myturf.z ) {
					huduser.show_message( this.declare_message, 1 );
				}
			}
			return;
		}

		// Function from file: bots.dm
		public virtual void Emag( dynamic user = null ) {
			
			if ( this.locked ) {
				this.locked = false;
				this.emagged = 1;
				GlobalFuncs.to_chat( user, "<span class='warning'>You bypass " + this + "'s controls.</span>" );
			}

			if ( !this.locked && this.open ) {
				this.emagged = 2;
			}
			return;
		}

		// Function from file: bots.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				this.explode();
			}
			return;
		}

		// Function from file: bots.dm
		public virtual void explode(  ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: bots.dm
		public virtual void turn_off(  ) {
			this.on = false;
			this.set_light( 0 );
			return;
		}

		// Function from file: bots.dm
		public virtual bool turn_on(  ) {
			
			if ( this.stat != 0 ) {
				return false;
			}
			this.on = true;
			this.set_light( Lang13.Initial( this, "luminosity" ) );
			return true;
		}

	}

}