// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Blob : Obj_Effect {

		public int? point_return = 0;
		public double health = 30;
		public int maxhealth = 30;
		public int health_regen = 2;
		public int pulse_timestamp = 0;
		public double brute_resist = 0.5;
		public bool fire_resist = true;
		public bool atmosblock = false;
		public Mob_Camera_Blob overmind = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 1;
			this.anchored = 1;
			this.explosion_block = 1;
			this.icon = "icons/mob/blob.dmi";
		}

		// Function from file: theblob.dm
		public Obj_Effect_Blob ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic Ablob = null;

			Ablob = GlobalFuncs.get_area( loc );

			if ( Ablob.blob_allowed ) {
				GlobalVars.blobs_legit.Add( this );
			}
			GlobalVars.blobs.Add( this );
			this.dir = Convert.ToInt32( Rand13.Pick(new object [] { 1, 2, 4, 8 }) );
			this.update_icon();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.ConsumeTile();

			if ( this.atmosblock ) {
				this.air_update_turf( true );
			}
			return;
		}

		// Function from file: theblob.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "It seems to be made of " + this.get_chem_name() + "." );
			return 0;
		}

		// Function from file: theblob.dm
		public override bool attack_alien( dynamic user = null ) {
			double damage = 0;

			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/attackblob.ogg", 50, 1 );
			this.visible_message( "<span class='danger'>" + user + " has slashed the " + this.name + "!</span>" );
			damage = Rand13.Int( 15, 30 );
			this.take_damage( damage, "brute", user );
			return false;
		}

		// Function from file: theblob.dm
		public override bool attack_animal( Mob_Living user = null ) {
			double damage = 0;

			
			if ( Lang13.Bool( user.faction.Contains( "blob" ) ) ) {
				return false;
			}
			user.changeNext_move( 8 );
			user.do_attack_animation( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/attackblob.ogg", 50, 1 );
			this.visible_message( new Txt( "<span class='danger'>" ).The( user ).item().str( " has attacked the " ).item( this.name ).str( "!</span>" ).ToString() );
			damage = Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );
			this.take_damage( damage, ((dynamic)user).melee_damage_type, user );
			return false;
		}

		// Function from file: theblob.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/attackblob.ogg", 50, 1 );
			this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " has attacked the " ).item( this.name ).str( " with " ).the( A ).item().str( "!</span>" ).ToString() );

			if ( A.damtype == "fire" ) {
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );
			}
			this.take_damage( A.force, A.damtype, user );
			return null;
		}

		// Function from file: theblob.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );
			this.take_damage( P.damage, P.damage_type, P );
			return 0;
		}

		// Function from file: theblob.dm
		public override bool fire_act( bool? air = null, dynamic exposed_temperature = null, double? exposed_volume = null ) {
			int damage = 0;

			base.fire_act( air, (object)(exposed_temperature), exposed_volume );
			damage = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( exposed_temperature * 0.01 ), 4 ) );
			this.take_damage( damage, "fire" );
			return false;
		}

		// Function from file: theblob.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			double damage = 0;

			base.ex_act( severity, (object)(target) );
			damage = 150 - ( severity ??0) * 20;
			this.take_damage( damage, "brute" );
			return false;
		}

		// Function from file: theblob.dm
		public override int? process( dynamic seconds = null ) {
			this.Life();
			return null;
		}

		// Function from file: theblob.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.overmind != null ) {
				this.color = this.overmind.blob_reagent_datum.color;
			} else {
				this.color = null;
			}
			return false;
		}

		// Function from file: theblob.dm
		public override bool CanAStarPass( dynamic ID = null, int dir = 0, dynamic caller = null ) {
			bool _default = false;

			Ent_Dynamic mover = null;

			_default = false;

			if ( caller is Ent_Dynamic ) {
				mover = caller;
				_default = _default || mover.checkpass( 8 ) != 0;
			}
			return _default;
		}

		// Function from file: theblob.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( height == 0 ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 8 ) != 0 ) {
				return true;
			}
			return false;
		}

		// Function from file: theblob.dm
		public override bool BlockSuperconductivity(  ) {
			return this.atmosblock;
		}

		// Function from file: theblob.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			return !this.atmosblock;
		}

		// Function from file: theblob.dm
		public override dynamic Destroy(  ) {
			dynamic Ablob = null;

			
			if ( this.atmosblock ) {
				this.atmosblock = false;
				this.air_update_turf( true );
			}
			Ablob = GlobalFuncs.get_area( this.loc );

			if ( Ablob.blob_allowed ) {
				GlobalVars.blobs_legit.Remove( this );
			}
			GlobalVars.blobs.Remove( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/splat.ogg", 50, 1 );
			return base.Destroy();
		}

		// Function from file: theblob.dm
		public string get_chem_name(  ) {
			
			if ( this.overmind != null ) {
				return this.overmind.blob_reagent_datum.name;
			}
			return "an unknown variant";
		}

		// Function from file: theblob.dm
		public dynamic change_to( Type type = null, Mob_Camera_Blob controller = null ) {
			dynamic B = null;

			
			if ( !( type is Type ) ) {
				throw new Exception( "change_to(): invalid type for blob" );
				return null;
			}
			B = Lang13.Call( type, this.loc );

			if ( controller != null ) {
				B.overmind = controller;
			}
			((Obj_Effect_Blob)B).creation_action();
			B.update_icon();
			GlobalFuncs.qdel( this );
			return B;
		}

		// Function from file: theblob.dm
		public void take_damage( dynamic damage = null, dynamic damage_type = null, dynamic cause = null, bool? overmind_reagent_trigger = null ) {
			overmind_reagent_trigger = overmind_reagent_trigger ?? true;

			
			dynamic _a = damage_type; // Was a switch-case, sorry for the mess.
			if ( _a=="brute" ) {
				damage = Num13.MaxInt( Convert.ToInt32( damage * this.brute_resist ), 0 );
			} else if ( _a=="fire" ) {
				damage = Num13.MaxInt( Convert.ToInt32( damage * this.fire_resist ), 0 );
			} else if ( _a=="clone" ) {
				
			} else {
				damage = 0;
			}

			if ( this.overmind != null && overmind_reagent_trigger == true ) {
				damage = ((Reagent_Blob)this.overmind.blob_reagent_datum).damage_reaction( this, this.health, damage, damage_type, cause );
			}
			this.health -= Convert.ToDouble( damage );
			this.update_icon();
			this.check_health( cause );
			return;
		}

		// Function from file: theblob.dm
		public dynamic expand( dynamic T = null, Mob_Camera_Blob controller = null ) {
			ByTable dirs = null;
			double i = 0;
			dynamic dirn = null;
			int? make_blob = null;
			Ent_Static A = null;
			Obj_Effect_Blob_Normal B = null;

			
			if ( !Lang13.Bool( T ) ) {
				dirs = new ByTable(new object [] { 1, 2, 4, 8 });

				foreach (dynamic _a in Lang13.IterateRange( 1, 4 )) {
					i = _a;
					
					dirn = Rand13.PickFromTable( dirs );
					dirs.Remove( dirn );
					T = Map13.GetStep( this, Convert.ToInt32( dirn ) );

					if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Blob), T ) ) ) {
						break;
					} else {
						T = null;
					}
				}
			}

			if ( !Lang13.Bool( T ) ) {
				return 0;
			}
			make_blob = GlobalVars.TRUE;

			if ( T is Tile_Space && !Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), T ) ) && Rand13.PercentChance( 80 ) ) {
				make_blob = GlobalVars.FALSE;
				GlobalFuncs.playsound( this.loc, "sound/effects/splat.ogg", 50, 1 );
			}
			this.ConsumeTile();

			if ( !((Ent_Static)T).CanPass( this, T, 5 ) ) {
				make_blob = GlobalVars.FALSE;
				((Ent_Static)T).blob_act();
			}

			foreach (dynamic _b in Lang13.Enumerate( T, typeof(Ent_Static) )) {
				A = _b;
				

				if ( !A.CanPass( this, T, 5 ) ) {
					make_blob = GlobalVars.FALSE;
				}
				A.blob_act();
			}

			if ( Lang13.Bool( make_blob ) ) {
				B = new Obj_Effect_Blob_Normal( this.loc );

				if ( controller != null ) {
					B.overmind = controller;
				} else {
					B.overmind = this.overmind;
				}
				B.density = true;

				if ( ((Base_Static)T).Enter( B, this ) ) {
					B.density = Lang13.Bool( Lang13.Initial( B, "density" ) );
					B.loc = T;
					B.update_icon();

					if ( B.overmind != null ) {
						((Reagent_Blob)B.overmind.blob_reagent_datum).expand_reaction( this, B, T );
					}
					return B;
				} else {
					this.blob_attack_animation( T, controller );
					((Ent_Static)T).blob_act();
					GlobalFuncs.qdel( B );
					return null;
				}
			} else {
				this.blob_attack_animation( T, controller );
			}
			return null;
		}

		// Function from file: theblob.dm
		public dynamic blob_attack_animation( dynamic A = null, Mob_Camera_Blob controller = null ) {
			dynamic O = null;
			Mob_Camera_Blob BO = null;

			O = GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Overlay_Temp_Blob), this.loc );

			if ( controller != null ) {
				BO = controller;
				O.color = BO.blob_reagent_datum.color;
				O.alpha = 200;
			} else if ( this.overmind != null ) {
				O.color = this.overmind.blob_reagent_datum.color;
			}

			if ( Lang13.Bool( A ) ) {
				((Ent_Dynamic)O).do_attack_animation( A );
			}
			return O;
		}

		// Function from file: theblob.dm
		public void ConsumeTile(  ) {
			Ent_Static A = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Ent_Static) )) {
				A = _a;
				
				A.blob_act();
			}

			if ( this.loc is Tile_Simulated_Wall ) {
				this.loc.blob_act();
			}
			return;
		}

		// Function from file: theblob.dm
		public virtual bool Be_Pulsed(  ) {
			
			if ( this.pulse_timestamp <= Game13.time ) {
				this.ConsumeTile();
				this.health = Num13.MinInt( this.maxhealth, ((int)( this.health + this.health_regen )) );
				this.update_icon();
				this.pulse_timestamp = Game13.time + 10;
				return true;
			}
			return false;
		}

		// Function from file: theblob.dm
		public void Pulse_Area( Mob_Camera_Blob pulsing_overmind = null, int? claim_range = null, int? pulse_range = null, int? expand_range = null ) {
			pulsing_overmind = pulsing_overmind ?? this.overmind;
			claim_range = claim_range ?? 10;
			pulse_range = pulse_range ?? 3;
			expand_range = expand_range ?? 2;

			Obj_Effect_Blob B = null;
			Obj_Effect_Blob B2 = null;
			Obj_Effect_Blob B3 = null;

			this.Be_Pulsed();

			if ( Lang13.Bool( claim_range ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.ultra_range( claim_range, this, true ), typeof(Obj_Effect_Blob) )) {
					B = _a;
					

					if ( !( B.overmind != null ) && !( B is Obj_Effect_Blob_Core ) && Rand13.PercentChance( 30 ) ) {
						B.overmind = pulsing_overmind;
						B.update_icon();
					}
				}
			}

			if ( Lang13.Bool( pulse_range ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, pulse_range ), typeof(Obj_Effect_Blob) )) {
					B2 = _b;
					
					B2.Be_Pulsed();
				}
			}

			if ( Lang13.Bool( expand_range ) ) {
				this.expand();

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, expand_range ), typeof(Obj_Effect_Blob) )) {
					B3 = _c;
					

					if ( Rand13.PercentChance( Num13.MaxInt( 13 - Map13.GetDistance( GlobalFuncs.get_turf( this ), GlobalFuncs.get_turf( B3 ) ) * 4, 1 ) ) ) {
						B3.expand();
					}
				}
			}
			return;
		}

		// Function from file: theblob.dm
		public virtual void Life(  ) {
			return;
		}

		// Function from file: theblob.dm
		public virtual void check_health( dynamic cause = null ) {
			this.health = Num13.MaxInt( 0, Num13.MinInt( ((int)( this.health )), this.maxhealth ) );

			if ( this.health <= 0 ) {
				
				if ( this.overmind != null ) {
					((Reagent_Blob)this.overmind.blob_reagent_datum).death_reaction( this, cause );
				}
				GlobalFuncs.qdel( this );
				return;
			}
			return;
		}

		// Function from file: theblob.dm
		public void creation_action(  ) {
			return;
		}

	}

}