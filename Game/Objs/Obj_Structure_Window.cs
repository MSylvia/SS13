// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window : Obj_Structure {

		public double health = 10;
		public int ini_dir = 0;
		public int d_state = 1;
		public Type shardtype = typeof(Obj_Item_Weapon_Shard);
		public Type sheettype = typeof(Obj_Item_Stack_Sheet_Glass_Glass);
		public int sheetamount = 1;
		public bool reinforced = false;
		public Obj_Overlays damage_overlay = null;
		public string cracked_base = "crack";
		public int fire_temp_threshold = 800;
		public int fire_volume_mod = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 40521;
			this.anchored = 1;
			this.penetration_dampening = 1;
			this.icon_state = "window";
			this.layer = 3.2;
		}

		// Function from file: window.dm
		public Obj_Structure_Window ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.flags |= 512;
			this.ini_dir = this.dir;
			this.update_nearby_tiles();
			this.update_nearby_icons();
			this.update_icon();
			return;
		}

		// Function from file: window.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( ( exposed_temperature ??0) > this.fire_temp_threshold + 273.41 ) {
				this.health -= Num13.Floor( exposed_volume / this.fire_volume_mod );
				this.healthcheck( null, false );
			}
			base.fire_act( air, exposed_temperature, exposed_volume );
			return false;
		}

		// Function from file: window.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			return null;
		}

		// Function from file: window.dm
		public override bool forceMove( dynamic destination = null, int? no_tp = null ) {
			Ent_Static T = null;

			T = this.loc;
			base.forceMove( (object)(destination), no_tp );
			this.update_nearby_icons( T );
			this.update_nearby_icons();
			this.update_nearby_tiles( T );
			this.update_nearby_tiles();
			return false;
		}

		// Function from file: window.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			this.update_nearby_tiles();
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.dir = this.ini_dir;
			this.update_nearby_tiles();
			return false;
		}

		// Function from file: window.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			brokenup = brokenup ?? 0;

			this.density = false;
			this.update_nearby_tiles();
			this.update_nearby_icons();

			if ( Lang13.Bool( brokenup ) ) {
				
				if ( this.loc != null ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "shatter", 70, 1 );
				}
				GlobalFuncs.getFromPool( this.shardtype, this.loc, this.sheetamount );

				if ( this.reinforced ) {
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Rods), this.loc, this.sheetamount );
				}
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: window.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic G = null;
			Mob M = null;
			dynamic gstate = null;
			double pdiff = 0;
			dynamic WT = null;
			dynamic WT2 = null;

			
			if ( a is Obj_Item_Weapon_Grab && this.Adjacent( b ) ) {
				G = a;

				if ( G.affecting is Mob_Living ) {
					M = G.affecting;
					gstate = G.state;
					GlobalFuncs.returnToPool( a );

					dynamic _a = gstate; // Was a switch-case, sorry for the mess.
					if ( 3<=_a&&_a<=5 ) {
						M.Weaken( 3 );
						((dynamic)M).apply_damage( 20 );
						this.health -= 20;
						this.visible_message( new Txt( "<span class='danger'>" ).The( b ).item().str( " crushes " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='danger'>You crush " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString() );
					} else if ( _a==1 ) {
						((dynamic)M).apply_damage( 5 );
						this.visible_message( new Txt( "<span class='warning'>" ).The( b ).item().str( " shoves " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>You shove " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString() );
					} else if ( _a==2 ) {
						((dynamic)M).apply_damage( 10 );
						this.health -= 5;
						this.visible_message( new Txt( "<span class='danger'>" ).The( b ).item().str( " slams " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='danger'>You slam " ).the( M ).item().str( " into " ).the( this ).item().str( "!</span>" ).ToString() );
					}
					this.healthcheck( b );
					M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been window slammed by " + b.name + " (" + b.ckey + ") (" + gstate + ").</font>" );
					b.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Window slammed " + M.name + " (" + gstate + ").</font>" );
					GlobalFuncs.msg_admin_attack( "" + b.name + " (" + b.ckey + ") window slammed " + M.name + " (" + M.ckey + ") (" + gstate + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + b.x + ";Y=" + b.y + ";Z=" + b.z + "'>JMP</a>)" );
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "" + b.name + " (" + b.ckey + ") window slammed " + M.name + " (" + M.ckey + ") (" + gstate + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + b.x + ";Y=" + b.y + ";Z=" + b.z + "'>JMP</a>)" ) ) );
					return null;
				}
			}

			if ( this.reinforced ) {
				
				switch ((int)( this.d_state )) {
					case 3:
						
						if ( a is Obj_Item_Weapon_Screwdriver ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " unfastens " ).the( this ).item().str( " from its frame.</span>" ).ToString(), new Txt( "<span class='notice'>You unfasten " ).the( this ).item().str( " from its frame.</span>" ).ToString() );
							this.d_state = 2;
							return null;
						}
						break;
					case 2:
						
						if ( a is Obj_Item_Weapon_Screwdriver ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " fastens " ).the( this ).item().str( " to its frame.</span>" ).ToString(), new Txt( "<span class='notice'>You fasten " ).the( this ).item().str( " to its frame.</span>" ).ToString() );
							this.d_state = 3;
							return null;
						}

						if ( a is Obj_Item_Weapon_Crowbar ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " pries " ).the( this ).item().str( " from its frame.</span>" ).ToString(), new Txt( "<span class='notice'>You pry " ).the( this ).item().str( " from its frame.</span>" ).ToString() );
							this.d_state = 1;
							return null;
						}
						break;
					case 1:
						
						if ( a is Obj_Item_Weapon_Crowbar ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " pries " ).the( this ).item().str( " into its frame.</span>" ).ToString(), new Txt( "<span class='notice'>You pry " ).the( this ).item().str( " into its frame.</span>" ).ToString() );
							this.d_state = 2;
							return null;
						}

						if ( a is Obj_Item_Weapon_Screwdriver ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " unfastens " ).the( this ).item().str( "'s frame from the floor.</span>" ).ToString(), new Txt( "<span class='notice'>You unfasten " ).the( this ).item().str( "'s frame from the floor.</span>" ).ToString() );
							this.d_state = 0;
							this.anchored = 0;
							this.update_nearby_tiles();
							this.update_nearby_icons();
							this.update_icon();
							pdiff = GlobalFuncs.performWallPressureCheck( this.loc );

							if ( pdiff > 0 ) {
								GlobalFuncs.message_admins( "Window with pdiff " + pdiff + " deanchored by " + b.real_name + " (" + GlobalFuncs.formatPlayerPanel( b, b.ckey ) + ") at " + GlobalFuncs.formatJumpTo( this.loc ) + "!" );
								GlobalFuncs.log_admin( "Window with pdiff " + pdiff + " deanchored by " + b.real_name + " (" + b.ckey + ") at " + this.loc + "!" );
							}
							return null;
						}
						break;
					case 0:
						
						if ( a is Obj_Item_Weapon_Screwdriver ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " fastens " ).the( this ).item().str( "'s frame to the floor.</span>" ).ToString(), new Txt( "<span class='notice'>You fasten " ).the( this ).item().str( "'s frame to the floor.</span>" ).ToString() );
							this.d_state = 1;
							this.anchored = 1;
							this.update_nearby_tiles();
							this.update_nearby_icons();
							this.update_icon();
							return null;
						}

						if ( a is Obj_Item_Weapon_Weldingtool ) {
							WT = a;

							if ( Lang13.Bool( WT.remove_fuel( 0 ) ) ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " starts disassembling " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start disassembling " ).the( this ).item().str( ".</span>" ).ToString() );

								if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 0 ) {
									GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
									((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " disassembles " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You disassemble " ).the( this ).item().str( ".</span>" ).ToString() );
									GlobalFuncs.getFromPool( this.sheettype, GlobalFuncs.get_turf( this ), this.sheetamount );
									GlobalFuncs.qdel( this );
									return null;
								}
							} else {
								GlobalFuncs.to_chat( b, "<span class='warning'>You need more welding fuel to complete this task.</span>" );
								return null;
							}
						}
						break;
				}
			} else if ( !this.reinforced ) {
				
				if ( a is Obj_Item_Weapon_Screwdriver ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 75, 1 );
					((Ent_Static)b).visible_message( new Txt( "<span class='" ).item( ( this.d_state != 0 ? "warning" : "notice" ) ).str( "'>" ).item( b ).str( " " ).item( ( this.d_state != 0 ? "un" : "" ) ).str( "fastens " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You " ).item( ( this.d_state != 0 ? "un" : "" ) ).str( "fasten " ).the( this ).item().str( ".</span>" ).ToString() );
					this.d_state = !( this.d_state != 0 ) ?1:0;
					this.anchored = !Lang13.Bool( this.anchored );
					this.update_nearby_tiles();
					this.update_nearby_icons();
					this.update_icon();
					return null;
				}

				if ( a is Obj_Item_Weapon_Weldingtool && !( this.d_state != 0 ) ) {
					WT2 = a;

					if ( Lang13.Bool( WT2.remove_fuel( 0 ) ) ) {
						GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " starts disassembling " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start disassembling " ).the( this ).item().str( ".</span>" ).ToString() );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 0 ) {
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " disassembles " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You disassemble " ).the( this ).item().str( ".</span>" ).ToString() );
							GlobalFuncs.getFromPool( this.sheettype, GlobalFuncs.get_turf( this ), this.sheetamount );
							this.Destroy();
							return null;
						}
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>You need more welding fuel to complete this task.</span>" );
						return null;
					}
				}
			}

			if ( a.damtype == "brute" || a.damtype == "fire" ) {
				((Mob)b).delayNextAttack( 10 );
				this.health -= Convert.ToDouble( a.force );
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).The( b ).item().str( " hits " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You hit " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString() );
				this.healthcheck( b );
				return null;
			} else {
				GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 75, 1 );
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: window.dm
		public override void attack_slime( Mob_Living_Carbon_Slime user = null ) {
			
			if ( !( user is Mob_Living_Carbon_Slime_Adult ) ) {
				return;
			}
			this.attack_generic( user, Rand13.Int( 10, 15 ) );
			return;
		}

		// Function from file: window.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;

			M = user;

			if ( Convert.ToDouble( ((dynamic)M).melee_damage_upper ) <= 0 ) {
				return null;
			}
			this.attack_generic( M, Lang13.IntNullable( ((dynamic)M).melee_damage_upper ) );
			return null;
		}

		// Function from file: window.dm
		public override dynamic attack_alien( Mob user = null ) {
			
			if ( user is Mob_Living_Carbon_Alien_Larva ) {
				return null;
			}
			this.attack_generic( user, 15 );
			return null;
		}

		// Function from file: window.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: window.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( a.mutations.Contains( 4 ) ) ) {
				((Ent_Dynamic)a).say( Rand13.Pick(new object [] { ";RAAAAAAAARGH!", ";HNNNNNNNNNGGGGGGH!", ";GWAAAAAAAARRRHHH!", "NNNNNNNNGGGGGGGGHH!", ";AAAAAAARRRGH!" }) );
				((Ent_Static)a).visible_message( new Txt( "<span class='danger'>" ).item( a ).str( " smashes " ).the( this ).item().str( "!</span>" ).ToString() );
				this.health -= 25;
				this.healthcheck();
				((Mob)a).delayNextAttack( 8 );
			} else if ( Task13.User.a_intent == "hurt" ) {
				((Mob)a).delayNextAttack( 10 );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/glassknock.ogg", 100, 1 );
				((Ent_Static)a).visible_message( new Txt( "<span class='warning'>" ).item( a ).str( " bangs against " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>You bang against " ).the( this ).item().str( "!</span>" ).ToString(), "You hear banging." );
			} else {
				((Mob)a).delayNextAttack( 10 );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/glassknock.ogg", 50, 1 );
				((Ent_Static)a).visible_message( new Txt( "<span class='notice'>" ).item( a ).str( " knocks on " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You knock on " ).the( this ).item().str( ".</span>" ).ToString(), "You hear knocking." );
			}
			return null;
		}

		// Function from file: window.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			Ent_Static M = null;
			Ent_Static I = null;

			base.hitby( AM, (object)(speed), dir );

			if ( AM is Mob ) {
				M = AM;
				this.health -= 10;
				this.healthcheck( M );
				this.visible_message( new Txt( "<span class='danger'>" ).The( M ).item().str( " slams into " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='danger'>You slam into " ).the( this ).item().str( ".</span>" ).ToString() );
			} else if ( AM is Obj ) {
				I = AM;
				this.health -= Convert.ToDouble( ((dynamic)I).throwforce );
				this.healthcheck();
				this.visible_message( new Txt( "<span class='danger'>" ).The( I ).item().str( " slams into " ).the( this ).item().str( ".</span>" ).ToString() );
			}
			return;
		}

		// Function from file: window.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Ent_Dynamic && ((Ent_Static)mover).checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			}
			return true;
		}

		// Function from file: window.dm
		public override bool CheckExit( Ent_Dynamic mover = null, Ent_Static target = null ) {
			
			if ( mover is Ent_Dynamic && mover.checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( mover.loc, target ) == this.dir ) {
				return !this.density;
			}
			return true;
		}

		// Function from file: window.dm
		public override bool blob_act( dynamic severity = null ) {
			this.health -= Rand13.Int( 30, 50 );
			this.healthcheck();
			return false;
		}

		// Function from file: window.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					this.health -= Rand13.Int( 100, 150 );
					this.healthcheck();
					return false;
					break;
				case 2:
					this.health -= Rand13.Int( 20, 50 );
					this.healthcheck();
					return false;
					break;
				case 3:
					this.health -= Rand13.Int( 5, 15 );
					this.healthcheck();
					return false;
					break;
			}
			return false;
		}

		// Function from file: window.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.healthcheck( Proj.firer );
			return null;
		}

		// Function from file: window.dm
		public virtual bool update_nearby_icons( dynamic T = null ) {
			dynamic direction = null;
			Obj_Structure_Window W = null;

			
			if ( !( this.loc != null ) ) {
				return false;
			}

			if ( !Lang13.Bool( T ) ) {
				T = GlobalFuncs.get_turf( this );
			}
			this.update_icon();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				direction = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( Map13.GetStep( T, Convert.ToInt32( direction ) ), typeof(Obj_Structure_Window) )) {
					W = _a;
					
					W.update_icon();
				}
			}
			return false;
		}

		// Function from file: window.dm
		public virtual bool update_nearby_tiles( dynamic T = null ) {
			
			if ( GlobalVars.air_master == null ) {
				return false;
			}

			if ( !Lang13.Bool( T ) ) {
				T = GlobalFuncs.get_turf( this );
			}

			if ( T is Tile ) {
				GlobalVars.air_master.mark_for_update( T );
			}
			return true;
		}

		// Function from file: window.dm
		public virtual bool can_be_reached( Ent_Static user = null ) {
			Obj O = null;

			
			if ( !this.is_fulltile() ) {
				
				if ( ( Map13.GetDistance( user, this ) & this.dir ) != 0 ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj) )) {
						O = _a;
						

						if ( !O.CanPass( user, user.loc, 1, false ) ) {
							return false;
						}
					}
				}
			}
			return true;
		}

		// Function from file: window.dm
		public void attack_generic( Mob user = null, int? damage = null ) {
			damage = damage ?? 0;

			user.delayNextAttack( 10 );
			this.health -= damage ??0;
			user.visible_message( new Txt( "<span class='danger'>" ).The( user ).item().str( " smashes into " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='danger'>You smash into " ).the( this ).item().str( "!</span>" ).ToString() );
			this.healthcheck( user );
			return;
		}

		// Function from file: window.dm
		public virtual bool is_fulltile(  ) {
			return false;
		}

		// Function from file: window.dm
		public virtual void healthcheck( dynamic M = null, bool? sound = null ) {
			sound = sound ?? true;

			double pdiff = 0;
			int damage_fraction = 0;

			
			if ( this.health <= 0 ) {
				
				if ( Lang13.Bool( M ) ) {
					pdiff = GlobalFuncs.performWallPressureCheck( this.loc );

					if ( pdiff > 0 ) {
						GlobalFuncs.message_admins( "Window with pdiff " + pdiff + " at " + GlobalFuncs.formatJumpTo( this.loc ) + " destroyed by " + M.real_name + " (" + GlobalFuncs.formatPlayerPanel( M, M.ckey ) + ")!" );
						GlobalFuncs.log_admin( "Window with pdiff " + pdiff + " at " + this.loc + " destroyed by " + M.real_name + " (" + M.ckey + ")!" );
					}
				}
				this.Destroy( 1 );
			} else {
				
				if ( sound == true ) {
					GlobalFuncs.playsound( this.loc, "sound/effects/Glasshit.ogg", 100, 1 );
				}

				if ( !( this.damage_overlay != null ) ) {
					this.damage_overlay = new Obj_Overlays( this );
					this.damage_overlay.icon = new Icon( "icons/obj/structures.dmi" );
					this.damage_overlay.dir = this.dir;
				}
				this.overlays.Cut();

				if ( this.health < Convert.ToDouble( Lang13.Initial( this, "health" ) ) ) {
					damage_fraction = ( Num13.Floor( Convert.ToDouble( ( Lang13.Initial( this, "health" ) - this.health ) / Lang13.Initial( this, "health" ) * 5 ) ) + 1 <= 1 ? 1 : ( Num13.Floor( Convert.ToDouble( ( Lang13.Initial( this, "health" ) - this.health ) / Lang13.Initial( this, "health" ) * 5 ) ) + 1 >= 5 ? 5 : Num13.Floor( Convert.ToDouble( ( Lang13.Initial( this, "health" ) - this.health ) / Lang13.Initial( this, "health" ) * 5 ) ) + 1 ) );
					this.damage_overlay.icon_state = "" + this.cracked_base + damage_fraction;
					this.overlays.Add( this.damage_overlay );
				}
			}
			return;
		}

		// Function from file: window.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( user, "It appears to be completely loose and movable." );
			}

			if ( this.health >= Convert.ToDouble( Lang13.Initial( this, "health" ) ) ) {
				GlobalFuncs.to_chat( user, "It's in perfect shape, not even a scratch." );
			} else if ( this.health >= Convert.ToDouble( Lang13.Initial( this, "health" ) * 0.8 ) ) {
				GlobalFuncs.to_chat( user, "It has a few scratches and a small impact." );
			} else if ( this.health >= Convert.ToDouble( Lang13.Initial( this, "health" ) * 0.5 ) ) {
				GlobalFuncs.to_chat( user, "It has a few impacts and some cracks running from them." );
			} else if ( this.health >= Convert.ToDouble( Lang13.Initial( this, "health" ) * 0.2 ) ) {
				GlobalFuncs.to_chat( user, "It's covered in impact marks and most of the outer sheet is crackled." );
			} else {
				GlobalFuncs.to_chat( user, "It's completely crackled over multiple layers, it's a miracle it's even standing." );
			}

			if ( this.reinforced ) {
				
				switch ((int)( this.d_state )) {
					case 3:
						GlobalFuncs.to_chat( user, "It is firmly secured." );
						break;
					case 2:
						GlobalFuncs.to_chat( user, "It appears it was unfastened from its frame." );
						break;
					case 1:
						GlobalFuncs.to_chat( user, "It appears to be loose from its frame." );
						break;
				}
			}
			return null;
		}

		// Function from file: window.dm
		public override int projectile_check(  ) {
			return 2;
		}

		// Function from file: window.dm
		[Verb]
		[VerbInfo( name: "Rotate Window Clockwise", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool revrotate(  ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='warning'>" ).The( this ).item().str( " is fastened to the floor, therefore you can't rotate it!</span>" ).ToString() );
				return false;
			}
			this.update_nearby_tiles();
			this.dir = Num13.Rotate( this.dir, 270 );
			this.update_nearby_tiles();
			this.ini_dir = this.dir;
			return false;
		}

		// Function from file: window.dm
		[Verb]
		[VerbInfo( name: "Rotate Window Counter-Clockwise", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool rotate(  ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='warning'>" ).The( this ).item().str( " is fastened to the floor, therefore you can't rotate it!</span>" ).ToString() );
				return false;
			}
			this.update_nearby_tiles();
			this.dir = Num13.Rotate( this.dir, 90 );
			this.update_nearby_tiles();
			this.ini_dir = this.dir;
			return false;
		}

	}

}