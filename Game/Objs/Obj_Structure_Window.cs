// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window : Obj_Structure {

		public double maxhealth = 25;
		public double health = 0;
		public double? ini_dir = null;
		public dynamic state = 0;
		public bool? reinf = false;
		public bool disassembled = false;
		public string wtype = "glass";
		public bool fulltile = false;
		public ByTable storeditems = new ByTable();
		public Image crack_overlay = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 40521;
			this.anchored = 1;
			this.flags = 512;
			this.can_be_unanchored = true;
			this.icon_state = "window";
			this.layer = 3.2;
		}

		// Function from file: window.dm
		public Obj_Structure_Window ( dynamic Loc = null, bool? re = null ) : base( (object)(Loc) ) {
			re = re ?? false;

			Obj_Item_Stack_Rods R = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.health = this.maxhealth;

			if ( re == true ) {
				this.reinf = re;
			}

			if ( this.reinf == true ) {
				this.state = this.anchored * 2;
			}
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( !Lang13.Bool( this.flags & 128 ) ) {
					this.storeditems.Add( new Obj_Item_Weapon_Shard( this ) );

					if ( this.fulltile ) {
						this.storeditems.Add( new Obj_Item_Weapon_Shard( this ) );
					}

					if ( this.reinf == true ) {
						R = new Obj_Item_Stack_Rods( this );
						this.storeditems.Add( R );

						if ( this.fulltile ) {
							R.add( true );
						}
					}
				}
				return;
			}));
			this.ini_dir = this.dir;
			this.air_update_turf( true );
			return;
		}

		// Function from file: window.dm
		public override bool CanAStarPass( dynamic ID = null, int dir = 0, dynamic caller = null ) {
			
			if ( !this.density ) {
				return true;
			}

			if ( this.dir == GlobalVars.SOUTHWEST || this.dir == dir ) {
				return false;
			}
			return true;
		}

		// Function from file: window.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			return false;
		}

		// Function from file: window.dm
		public override dynamic temperature_expose( GasMixture air = null, dynamic exposed_temperature = null, int? exposed_volume = null ) {
			
			if ( Convert.ToDouble( exposed_temperature ) > ( this.reinf == true ? 1600 : 800 ) + 273.41 ) {
				this.hit( Num13.Floor( ( exposed_volume ??0) / 100 ), false );
			}
			base.temperature_expose( air, (object)(exposed_temperature), exposed_volume );
			return null;
		}

		// Function from file: window.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			double ratio = 0;

			Task13.Schedule( 2, (Task13.Closure)(() => {
				
				if ( !( this != null ) ) {
					return;
				}

				if ( !this.fulltile ) {
					return;
				}
				ratio = this.health / this.maxhealth;
				ratio = GlobalFuncs.Ceiling( ratio * 4 ) * 25;

				if ( this.smooth != 0 ) {
					GlobalFuncs.smooth_icon( this );
				}
				this.overlays.Remove( this.crack_overlay );

				if ( ratio > 75 ) {
					return;
				}
				this.crack_overlay = new Image( "icons/obj/structures.dmi", "damage" + ratio, -( this.layer + 0.1 ) );
				this.overlays.Add( this.crack_overlay );
				return;
			}));
			return false;
		}

		// Function from file: window.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			
			if ( Map13.GetDistance( this.loc, T ) == this.dir ) {
				return !this.density;
			}

			if ( this.dir == GlobalVars.SOUTHWEST || this.dir == GlobalVars.SOUTHEAST || this.dir == GlobalVars.NORTHWEST || this.dir == GlobalVars.NORTHEAST ) {
				return !this.density;
			}
			return true;
		}

		// Function from file: window.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static T = null;

			T = this.loc;
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.dir = ((int)( this.ini_dir ??0 ));
			this.move_update_air( T );
			return false;
		}

		// Function from file: window.dm
		public override dynamic Destroy(  ) {
			this.density = false;
			this.air_update_turf( true );

			if ( !this.disassembled && !Lang13.Bool( this.flags & 128 ) ) {
				GlobalFuncs.playsound( this, "shatter", 70, 1 );
			}
			this.update_nearby_icons();
			return base.Destroy();
		}

		// Function from file: window.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( user.incapacitated() ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.__CallVerb("Rotate Window Clockwise" );
			}
			return false;
		}

		// Function from file: window.dm
		public override bool mech_melee_attack( Obj_Mecha M = null ) {
			
			if ( base.mech_melee_attack( M ) ) {
				this.hit( M.force, true );
			}
			return false;
		}

		// Function from file: window.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;
			Obj_Item_Stack_Sheet_Rglass RG = null;
			Obj_Item_Stack_Sheet_Glass G = null;

			
			if ( !this.can_be_reached( user ) ) {
				return 1;
			}
			this.add_fingerprint( user );

			if ( A is Obj_Item_Weapon_Weldingtool && user.a_intent == "help" ) {
				WT = A;

				if ( this.health < this.maxhealth ) {
					
					if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
						user.WriteMsg( "<span class='notice'>You begin repairing " + this + "...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 40, 1 );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							this.health = this.maxhealth;
							GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 50, 1 );
							this.update_nearby_icons();
							user.WriteMsg( "<span class='notice'>You repair " + this + ".</span>" );
						}
					}
				} else {
					user.WriteMsg( "<span class='warning'>" + this + " is already in good condition!</span>" );
				}
				return null;
			}

			if ( !Lang13.Bool( this.flags & 128 ) ) {
				
				if ( A is Obj_Item_Weapon_Screwdriver ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );

					if ( this.reinf == true && ( this.state == 2 || this.state == 1 ) ) {
						user.WriteMsg( ( this.state == 2 ? "<span class='notice'>You begin to unscrew the window from the frame...</span>" : "<span class='notice'>You begin to screw the window to the frame...</span>" ) );
					} else if ( this.reinf == true && this.state == 0 ) {
						user.WriteMsg( ( Lang13.Bool( this.anchored ) ? "<span class='notice'>You begin to unscrew the frame from the floor...</span>" : "<span class='notice'>You begin to screw the frame to the floor...</span>" ) );
					} else if ( !( this.reinf == true ) ) {
						user.WriteMsg( ( Lang13.Bool( this.anchored ) ? "<span class='notice'>You begin to unscrew the window from the floor...</span>" : "<span class='notice'>You begin to screw the window to the floor...</span>" ) );
					}

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						
						if ( this.reinf == true && ( this.state == 1 || this.state == 2 ) ) {
							this.state = ( this.state == 1 ? 2 : 1 );
							user.WriteMsg( ( this.state == 1 ? "<span class='notice'>You unfasten the window from the frame.</span>" : "<span class='notice'>You fasten the window to the frame.</span>" ) );
						} else if ( this.reinf == true && this.state == 0 ) {
							this.anchored = !Lang13.Bool( this.anchored );
							this.update_nearby_icons();
							user.WriteMsg( ( Lang13.Bool( this.anchored ) ? "<span class='notice'>You fasten the frame to the floor.</span>" : "<span class='notice'>You unfasten the frame from the floor.</span>" ) );
						} else if ( !( this.reinf == true ) ) {
							this.anchored = !Lang13.Bool( this.anchored );
							this.update_nearby_icons();
							user.WriteMsg( ( Lang13.Bool( this.anchored ) ? "<span class='notice'>You fasten the window to the floor.</span>" : "<span class='notice'>You unfasten the window.</span>" ) );
						}
					}
					return null;
				} else if ( A is Obj_Item_Weapon_Crowbar && this.reinf == true && ( this.state == 0 || this.state == 1 ) ) {
					user.WriteMsg( ( this.state == 0 ? "<span class='notice'>You begin to lever the window into the frame...</span>" : "<span class='notice'>You begin to lever the window out of the frame...</span>" ) );
					GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 75, 1 );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						this.state = ( this.state == 0 ? true : false );
						user.WriteMsg( ( this.state == 1 ? "<span class='notice'>You pry the window into the frame.</span>" : "<span class='notice'>You pry the window out of the frame.</span>" ) );
					}
					return null;
				} else if ( A is Obj_Item_Weapon_Wrench && !Lang13.Bool( this.anchored ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );
					user.WriteMsg( "<span class='notice'> You begin to disassemble " + this + "...</span>" );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						
						if ( this.disassembled ) {
							return null;
						}

						if ( this.reinf == true ) {
							RG = new Obj_Item_Stack_Sheet_Rglass( user.loc );
							RG.add_fingerprint( user );

							if ( this.fulltile ) {
								RG = new Obj_Item_Stack_Sheet_Rglass( user.loc );
								RG.add_fingerprint( user );
							}
						} else {
							G = new Obj_Item_Stack_Sheet_Glass( user.loc );
							G.add_fingerprint( user );

							if ( this.fulltile ) {
								G = new Obj_Item_Stack_Sheet_Glass( user.loc );
								G.add_fingerprint( user );
							}
						}
						GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
						this.disassembled = true;
						user.WriteMsg( "<span class='notice'>You successfully disassemble " + this + ".</span>" );
						GlobalFuncs.qdel( this );
					}
					return null;
				}
			}

			if ( A is Obj_Item_Weapon_Rcd ) {
				return null;
			}

			if ( A.damtype == "brute" || A.damtype == "fire" ) {
				((Mob)user).changeNext_move( 8 );
				this.hit( A.force );
			} else {
				GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 75, 1 );
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: window.dm
		public override bool attack_slime( Mob_Living_SimpleAnimal_Slime user = null ) {
			user.do_attack_animation( this );

			if ( !user.is_adult ) {
				return false;
			}
			this.attack_generic( user, Rand13.Int( 10, 15 ) );
			this.update_nearby_icons();
			return false;
		}

		// Function from file: window.dm
		public override bool attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;

			
			if ( !( user is Mob_Living_SimpleAnimal ) ) {
				return false;
			}
			M = user;
			M.do_attack_animation( this );

			if ( Convert.ToDouble( ((dynamic)M).melee_damage_upper ) <= 0 || ((dynamic)M).melee_damage_type != "brute" && ((dynamic)M).melee_damage_type != "fire" ) {
				return false;
			}
			this.attack_generic( M, Lang13.IntNullable( ((dynamic)M).melee_damage_upper ) );
			this.update_nearby_icons();
			return false;
		}

		// Function from file: window.dm
		public override bool attack_alien( dynamic user = null ) {
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( user is Mob_Living_Carbon_Alien_Larva ) {
				return false;
			}
			this.attack_generic( user, 15 );
			this.update_nearby_icons();
			return false;
		}

		// Function from file: window.dm
		public void update_nearby_icons(  ) {
			this.update_icon();

			if ( this.smooth != 0 ) {
				GlobalFuncs.smooth_icon_neighbors( this );
			}
			return;
		}

		// Function from file: window.dm
		public void spawnfragments(  ) {
			Ent_Static T = null;
			Obj_Item I = null;

			
			if ( Lang13.Bool( GlobalFuncs.qdeleted() ) ) {
				return;
			}
			T = this.loc;

			foreach (dynamic _a in Lang13.Enumerate( this.storeditems, typeof(Obj_Item) )) {
				I = _a;
				
				I.loc = T;
				this.transfer_fingerprints_to( I );
			}
			GlobalFuncs.qdel( this );
			this.update_nearby_icons();
			return;
		}

		// Function from file: window.dm
		public void hit( dynamic damage = null, bool? sound_effect = null ) {
			sound_effect = sound_effect ?? true;

			
			if ( this.reinf == true ) {
				damage *= 0.5;
			}
			this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( damage ) )) );
			this.update_nearby_icons();

			if ( sound_effect == true ) {
				GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 75, 1 );
			}

			if ( this.health <= 0 ) {
				this.spawnfragments();
				return;
			}
			return;
		}

		// Function from file: window.dm
		public bool can_be_reached( dynamic user = null ) {
			Obj O = null;

			
			if ( !this.fulltile ) {
				
				if ( ( Map13.GetDistance( user, this ) & this.dir ) != 0 ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj) )) {
						O = _a;
						

						if ( !O.CanPass( user, user.loc, 1 ) ) {
							return false;
						}
					}
				}
			}
			return true;
		}

		// Function from file: window.dm
		public void attack_generic( dynamic user = null, int? damage = null ) {
			damage = damage ?? 0;

			
			if ( !this.can_be_reached( user ) ) {
				return;
			}
			((Mob)user).changeNext_move( 8 );
			this.health -= damage ??0;

			if ( this.health <= 0 ) {
				((Ent_Static)user).visible_message( "<span class='danger'>" + user + " smashes through " + this + "!</span>" );
				this.spawnfragments();
			} else {
				((Ent_Static)user).visible_message( "<span class='danger'>" + user + " smashes into " + this + "!</span>" );
				GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 100, 1 );
			}
			return;
		}

		// Function from file: window.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: window.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( !this.can_be_reached( a ) ) {
				return null;
			}
			((Mob)a).changeNext_move( 8 );
			((Ent_Static)a).visible_message( "" + a + " knocks on " + this + "." );
			this.add_fingerprint( a );
			GlobalFuncs.playsound( this.loc, "sound/effects/Glassknock.ogg", 50, 1 );
			return null;
		}

		// Function from file: window.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			
			if ( !this.can_be_reached( hulk ) ) {
				return false;
			}
			base.attack_hulk( hulk, true );
			hulk.say( Rand13.Pick(new object [] { ";RAAAAAAAARGH!", ";HNNNNNNNNNGGGGGGH!", ";GWAAAAAAAARRRHHH!", "NNNNNNNNGGGGGGGGHH!", ";AAAAAAARRRGH!" }) );
			hulk.visible_message( "<span class='danger'>" + hulk + " smashes through " + this + "!</span>" );
			this.add_fingerprint( hulk );
			this.hit( 50 );
			return true;
		}

		// Function from file: window.dm
		public override void attack_tk( Mob_Living_Carbon_Human user = null ) {
			user.changeNext_move( 8 );
			user.visible_message( "<span class='notice'>Something knocks on " + this + ".</span>" );
			this.add_fingerprint( user );
			GlobalFuncs.playsound( this.loc, "sound/effects/Glassknock.ogg", 50, 1 );
			return;
		}

		// Function from file: window.dm
		public override bool hitby( Ent_Dynamic AM = null, bool? skipcatch = null, bool? hitpush = null, bool? blocked = null ) {
			dynamic tforce = null;
			Ent_Dynamic I = null;

			base.hitby( AM, skipcatch, hitpush, blocked );
			tforce = 0;

			if ( AM is Mob ) {
				tforce = 40;
			} else if ( AM is Obj ) {
				I = AM;
				tforce = ((dynamic)I).throwforce;
			}

			if ( this.reinf == true ) {
				tforce *= 0.25;
			}
			GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 100, 1 );
			this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( tforce ) )) );

			if ( this.health <= 7 && !( this.reinf == true ) ) {
				this.anchored = 0;
				this.update_nearby_icons();
				Map13.Step( this, Map13.GetDistance( AM, this ) );
			}

			if ( this.health <= 0 ) {
				this.spawnfragments();
			}
			this.update_nearby_icons();
			return false;
		}

		// Function from file: window.dm
		public override bool CheckExit( Ent_Dynamic mover = null, Tile target = null ) {
			
			if ( mover is Ent_Dynamic && mover.checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( mover.loc, target ) == this.dir ) {
				return false;
			}
			return true;
		}

		// Function from file: window.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( this.dir == GlobalVars.SOUTHWEST || this.dir == GlobalVars.SOUTHEAST || this.dir == GlobalVars.NORTHWEST || this.dir == GlobalVars.NORTHEAST ) {
				return false;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: window.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			
			if ( ( current_size ??0) >= 9 ) {
				this.spawnfragments();
			}
			return;
		}

		// Function from file: window.dm
		public override bool blob_act( dynamic severity = null ) {
			this.spawnfragments();
			return false;
		}

		// Function from file: window.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			if ( severity == 1 ) {
				GlobalFuncs.qdel( this );
			} else {
				this.spawnfragments();
			}
			return false;
		}

		// Function from file: window.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
				this.health -= Convert.ToDouble( P.damage );
				this.update_nearby_icons();
			}
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( this.health <= 0 ) {
				this.spawnfragments();
			}
			return null;
		}

		// Function from file: window.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='notice'>Alt-click to rotate it clockwise.</span>" );
			return 0;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ) )) {
				T = _a;
				

				if ( T is Tile_Space || T.loc is Zone_Space ) {
					S.WriteMsg( "<span class='warning'>Destroying this object has the potential to cause a hull breach. Aborting.</span>" );
					return;
				}
			}
			base.swarmer_act( S );
			return;
		}

		// Function from file: window.dm
		[Verb]
		[VerbInfo( name: "Rotate Window Clockwise", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool revrotate(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return false;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				Task13.User.WriteMsg( "<span class='warning'>It is fastened to the floor therefore you can't rotate it!</span>" );
				return false;
			}
			this.dir = Num13.Rotate( this.dir, 270 );
			this.air_update_turf( true );
			this.ini_dir = this.dir;
			this.add_fingerprint( Task13.User );
			return false;
		}

		// Function from file: window.dm
		[Verb]
		[VerbInfo( name: "Rotate Window Counter-Clockwise", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool rotate(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return false;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				Task13.User.WriteMsg( "<span class='warning'>It is fastened to the floor therefore you can't rotate it!</span>" );
				return false;
			}
			this.dir = Num13.Rotate( this.dir, 90 );
			this.air_update_turf( true );
			this.ini_dir = this.dir;
			this.add_fingerprint( Task13.User );
			return false;
		}

	}

}