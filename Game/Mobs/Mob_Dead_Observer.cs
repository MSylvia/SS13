// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Dead_Observer : Mob_Dead {

		public dynamic ghostMulti = null;
		public int can_reenter_corpse = 0;
		public dynamic hud = null;
		public bool bootime = false;
		public int next_poltergeist = 0;
		public int started_as_observer = 0;
		public int has_enabled_antagHUD = 0;
		public bool medHUD = false;
		public bool antagHUD = false;
		public dynamic following = null;
		public Ent_Static canclone = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 60;
			this.stat = 2;
			this.lockflags = 0;
			this.canmove = false;
			this.blinded = 0;
			this.anchored = 1;
			this.flags = 16;
			this.universal_understand = true;
			this.universal_speak = true;
			this.incorporeal_move = 1;
			this.icon = "icons/mob/mob.dmi";
			this.icon_state = "ghost1";
		}

		// Function from file: observer.dm
		public Mob_Dead_Observer ( dynamic body = null, bool? flags = null ) : base( (object)(body) ) {
			flags = flags ?? true;

			dynamic T = null;

			this.sight |= 60;
			this.see_invisible = 60;
			this.see_in_dark = 100;
			this.verbs.Add( typeof(Mob_Dead_Observer).GetMethod( "dead_tele" ) );
			this.add_spell( new Spell_AoeTurf_Boo(), "grey_spell_ready" );
			this.can_reenter_corpse = ( flags == true ?1:0) & 1;
			this.started_as_observer = ( flags == true ?1:0) & 2;
			this.stat = 2;

			if ( body is Mob ) {
				T = GlobalFuncs.get_turf( body );
				this.attack_log = body.attack_log;

				if ( !( this.attack_log is ByTable ) ) {
					this.attack_log = new ByTable();
				}
				this.icon = body.icon;
				this.icon_state = body.icon_state;
				this.overlays = body.overlays;

				if ( this.icon == null || this.icon_state == null ) {
					this.icon = Lang13.Initial( this, "icon" );
					this.icon_state = Lang13.Initial( this, "icon_state" );
				}
				this.alpha = 127;
				this.gender = body.gender;

				if ( Lang13.Bool( body.mind ) && Lang13.Bool( body.mind.name ) ) {
					this.name = body.mind.name;
				} else if ( Lang13.Bool( body.real_name ) ) {
					this.name = body.real_name;
				} else if ( this.gender == GlobalVars.MALE ) {
					this.name = GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.first_names_male ) ) + " " + GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.last_names ) );
				} else {
					this.name = GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.first_names_female ) ) + " " + GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.last_names ) );
				}
				this.mind = body.mind;
			}

			if ( !Lang13.Bool( T ) ) {
				T = Rand13.PickFromTable( GlobalVars.latejoin );
			}
			this.loc = T;

			if ( !Lang13.Bool( this.name ) ) {
				this.name = GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.first_names_male ) ) + " " + GlobalFuncs.capitalize( Rand13.PickFromTable( GlobalVars.last_names ) );
			}
			this.real_name = this.name;
			this.start_poltergeist_cooldown();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: Airflow.dm
		public override bool check_airflow_movable( double n = 0 ) {
			return false;
		}

		// Function from file: say.dm
		public override dynamic Hear( dynamic speech = null, dynamic rendered_speech = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { speech, rendered_speech } ).Extend(_);

			Ent_Dynamic source = null;
			dynamic source_turf = null;

			
			if ( _args[2] == null ) {
				_args[2] = "";
			}

			if ( this.client == null || !( _args[1].speaker != null ) ) {
				return null;
			}
			source = _args[1].speaker.GetSource();
			source_turf = GlobalFuncs.get_turf( source );

			if ( Map13.GetDistance( source_turf, this ) <= Convert.ToDouble( Game13.view ) ) {
				
				if ( Map13.FetchInView( null, this ).Contains( source_turf ) ) {
					_args[2] = "<B>" + _args[2] + "</B>";
				}
			} else if ( this.client != null && this.client.prefs != null ) {
				
				if ( !Lang13.Bool( _args[1].frequency ) ) {
					
					if ( ( this.client.prefs.toggles & 64 ) != 64 ) {
						return null;
					}
				} else if ( ( this.client.prefs.toggles & 8192 ) != 8192 ) {
					return null;
				}
			}
			GlobalFuncs.to_chat( this, new Txt( "<a href='?src=" ).Ref( this ).str( ";follow=" ).Ref( source ).str( "'>(Follow)</a> " ).item( _args[2] ).ToString() );
			return null;
		}

		// Function from file: say.dm
		public override string say_quote( dynamic text = null ) {
			string ending = null;

			ending = String13.SubStr( text, Lang13.Length( text ), 0 );

			if ( ending == "?" ) {
				return "" + Rand13.Pick(new object [] { "moans", "gripes", "grumps", "murmurs", "mumbles", "bleats" }) + ", " + text;
			} else if ( ending == "!" ) {
				return "" + Rand13.Pick(new object [] { "screams", "screeches", "howls" }) + ", " + text;
			}
			return "" + Rand13.Pick(new object [] { "whines", "cries", "spooks", "complains", "drones", "mutters" }) + ", " + text;
		}

		// Function from file: say.dm
		public override bool say( dynamic message = null, string speaking = null, Ent_Dynamic radio = null ) {
			bool _default = false;

			dynamic T = null;

			message = GlobalFuncs.trim( String13.SubStr( message, 1, 1024 ) );

			if ( !Lang13.Bool( message ) ) {
				return _default;
			}
			T = GlobalFuncs.get_turf( this );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]SAY: " + ( "" + GlobalFuncs.key_name( this ) + " (@" + T.x + "," + T.y + "," + T.z + ") Ghost: " + message ) ) );

			if ( this.client != null ) {
				
				if ( ( this.client.prefs.muted & 16 ) != 0 ) {
					GlobalFuncs.to_chat( this, "<span class='warning'>You cannot talk in deadchat (muted).</span>" );
					return _default;
				}

				if ( this.client.handle_spam_prevention( message, 16 ) ) {
					return _default;
				}
			}
			_default = this.say_dead( message ) != null;
			return _default;
		}

		// Function from file: logout.dm
		public override bool Logout(  ) {
			base.Logout();
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( this != null && !Lang13.Bool( this.key ) ) {
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return false;
		}

		// Function from file: login.dm
		public override dynamic Login(  ) {
			base.Login();

			if ( this.check_rights( 10 ) ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You are now an admin ghost.  Think of yourself as an AI that doesn't show up anywhere and cannot speak.  You can access any console or machine by standing next to it and clicking on it.  Abuse of this privilege may result in hilarity or removal of your flags, so caution is recommended.</span>" );
			}

			if ( this.canclone is Mob && ((dynamic)this.canclone).mind == this.mind ) {
				
				if ( this.can_reenter_corpse != 0 && this.canclone.loc is Obj_Machinery_DnaScannernew ) {
					
					foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST, GlobalVars.SOUTH, GlobalVars.WEST }) )) {
						this.dir = Convert.ToInt32( _a );
						

						if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this.canclone.loc, this.dir ) ) ) ) {
							this.WriteMsg( "sound/effects/adminhelp.ogg" );
							GlobalFuncs.to_chat( this, new Txt( "<span class='interface'><b><font size = 3>Your corpse has been placed into a cloning scanner. Return to your body if you want to be resurrected/cloned!</b> (Verbs -> Ghost -> Re-enter corpse, or <a href='?src=" ).Ref( this ).str( ";reentercorpse=1'>click here!</a>)</font></span>" ).ToString() );
						}
					}
				}
			}
			this.canclone = null;
			return null;
		}

		// Function from file: observer.dm
		public override dynamic dexterity_check(  ) {
			return 1;
		}

		// Function from file: observer.dm
		public override bool html_mob_check( Type typepath = null ) {
			return true;
		}

		// Function from file: observer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Mob A = null;
			dynamic target = null;
			dynamic M = null;
			dynamic target2 = null;
			Mob A2 = null;
			dynamic pos = null;
			dynamic T = null;
			dynamic targetarena = null;

			
			if ( Lang13.Bool( href_list["reentercorpse"] ) ) {
				
				if ( Task13.User is Mob_Dead_Observer ) {
					A = Task13.User;
					A.__CallVerb("Re-enter Corpse" );
				}
			}

			if ( Task13.User != this ) {
				return null;
			}
			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["follow"] ) ) {
				target = Lang13.FindObj( href_list["follow"] );

				if ( Lang13.Bool( target ) ) {
					
					if ( target is Mob_Living_Silicon_Ai ) {
						M = target;
						target = M.eyeobj;
					}
					this.manual_follow( target );
				}
			}

			if ( Lang13.Bool( href_list["jump"] ) ) {
				target2 = Lang13.FindObj( href_list["jump"] );
				A2 = Task13.User;
				GlobalFuncs.to_chat( A2, "Teleporting to " + target2 + "..." );

				if ( Lang13.Bool( target2 ) && target2 != Task13.User ) {
					pos = GlobalFuncs.get_turf( A2 );
					T = GlobalFuncs.get_turf( target2 );

					if ( T != pos ) {
						
						if ( !Lang13.Bool( T ) ) {
							GlobalFuncs.to_chat( A2, "<span class='warning'>Target not in a turf.</span>" );
							return null;
						}
						this.forceMove( T );
					}
					this.following = null;
				}
			}

			if ( Lang13.Bool( href_list["jumptoarenacood"] ) ) {
				targetarena = Lang13.FindObj( href_list["targetarena"] );
				Task13.User.loc = targetarena.center;
				GlobalFuncs.to_chat( Task13.User, "Remember to enable darkness to be able to see the spawns. Click on a green spawn between rounds to register on it." );
			}
			base.Topic( href, href_list, (object)(hclient) );
			return null;
		}

		// Function from file: observer.dm
		public override dynamic Stat(  ) {
			double timeleft = 0;

			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Station Time: " + GlobalFuncs.worldtime2text() );

				if ( GlobalVars.ticker != null ) {
					
					if ( Lang13.Bool( GlobalVars.ticker.mode ) ) {
						
						if ( GlobalVars.ticker.mode.name == "AI malfunction" ) {
							
							if ( GlobalVars.ticker.mode.malf_mode_declared ) {
								Interface13.Stat( null, "Time left: " + Num13.MaxInt( ((int)( GlobalVars.ticker.mode.AI_win_timeleft / ( GlobalVars.ticker.mode.apcs / 3 ) )), 0 ) );
							}
						}
					}
				}

				if ( GlobalVars.emergency_shuttle != null ) {
					
					if ( GlobalVars.emergency_shuttle.online && GlobalVars.emergency_shuttle.location < 2 ) {
						timeleft = GlobalVars.emergency_shuttle.timeleft();

						if ( timeleft != 0 ) {
							Interface13.Stat( null, "ETA-" + timeleft / 60 % 60 + ":" + GlobalFuncs.add_zero( String13.NumberToString( timeleft % 60 ), 2 ) );
						}
					}
				}
			}
			return null;
		}

		// Function from file: observer.dm
		public override bool is_active(  ) {
			return false;
		}

		// Function from file: observer.dm
		public override bool can_use_hands(  ) {
			return false;
		}

		// Function from file: observer.dm
		public void manual_stop_follow( dynamic target = null ) {
			
			if ( !Lang13.Bool( target ) ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You are not currently haunting anyone.</span>" );
				return;
			} else {
				GlobalFuncs.to_chat( this, new Txt( "<span class='sinister'>You are no longer haunting " ).the( target ).item().str( ".</span>" ).ToString() );
				((Ent_Dynamic)target).unlock_atom( this );
			}
			return;
		}

		// Function from file: observer.dm
		public void manual_follow( dynamic target = null ) {
			dynamic targetloc = null;
			dynamic targetarea = null;

			
			if ( Lang13.Bool( target ) ) {
				targetloc = GlobalFuncs.get_turf( target );
				targetarea = GlobalFuncs.get_area( target );

				if ( Lang13.Bool( targetarea ) && targetarea.anti_ethereal && !GlobalFuncs.isAdminGhost( Task13.User ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='sinister'>You can sense a sinister force surrounding that mob, your spooky body itself refuses to follow it.</span>" );
					return;
				}

				if ( Lang13.Bool( targetloc ) && targetloc.holy && ( !( this.invisibility != 0 ) || Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( this.mind ) ) ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You cannot follow a mob standing on holy grounds!</span>" );
					return;
				}

				if ( target != this ) {
					
					if ( Lang13.Bool( this.locked_to ) ) {
						
						if ( this.locked_to == target ) {
							return;
						}
						this.manual_stop_follow( this.locked_to );
					}
					((Ent_Dynamic)target).lock_atom( this );
					GlobalFuncs.to_chat( this, new Txt( "<span class='sinister'>You are now haunting " ).the( target ).item().str( "</span>" ).ToString() );
				}
			}
			return;
		}

		// Function from file: observer.dm
		[VerbInfo( name: "Teleport", desc: "Teleport to a location", group: "Ghost" )]
		public void dead_tele(  ) {
			dynamic A = null;
			Zone thearea = null;
			ByTable L = null;
			bool holyblock = false;
			dynamic T = null;
			dynamic T2 = null;

			
			if ( !( Task13.User is Mob_Dead_Observer ) ) {
				GlobalFuncs.to_chat( Task13.User, "Not when you're not dead!" );
				return;
			}
			Task13.User.verbs.Remove( typeof(Mob_Dead_Observer).GetMethod( "dead_tele" ) );
			Task13.Schedule( 30, (Task13.Closure)(() => {
				Task13.User.verbs.Add( typeof(Mob_Dead_Observer).GetMethod( "dead_tele" ) );
				return;
			}));
			A = Interface13.Input( "Area to jump to", "BOOYEA", A, null, GlobalVars.ghostteleportlocs, InputType.Null | InputType.Any );
			thearea = GlobalVars.ghostteleportlocs[A];

			if ( !( thearea != null ) ) {
				return;
			}

			if ( thearea != null && thearea.anti_ethereal && !GlobalFuncs.isAdminGhost( Task13.User ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='sinister'>As you are about to arrive, a strange dark form grabs you and sends you back where you came from.</span>" );
				return;
			}
			L = new ByTable();
			holyblock = false;

			if ( Task13.User.invisibility == 0 || GlobalVars.ticker != null && Lang13.Bool( GlobalVars.ticker.mode ) && GlobalVars.ticker.mode.name == "cult" && Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( Task13.User.mind ) ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_area_turfs( thearea.type ) )) {
					T = _a;
					

					if ( !T.holy ) {
						L.Add( T );
					} else {
						holyblock = true;
					}
				}
			} else {
				
				foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.get_area_turfs( thearea.type ) )) {
					T2 = _b;
					
					L.Add( T2 );
				}
			}

			if ( !( L != null ) || !( L.len != 0 ) ) {
				
				if ( holyblock ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This area has been entirely made into sacred grounds, you cannot enter it while you are in this plane of existence!</span>" );
				} else {
					GlobalFuncs.to_chat( Task13.User, "No area available." );
				}
			}
			Task13.User.loc = Rand13.PickFromTable( L );

			if ( Lang13.Bool( this.locked_to ) ) {
				this.manual_stop_follow( this.locked_to );
			}
			return;
		}

		// Function from file: observer.dm
		public void reset_poltergeist_cooldown(  ) {
			this.next_poltergeist = 0;
			return;
		}

		// Function from file: observer.dm
		public void start_poltergeist_cooldown(  ) {
			this.next_poltergeist = Game13.time + 300;
			return;
		}

		// Function from file: observer.dm
		public bool can_poltergeist( bool? start_cooldown = null ) {
			start_cooldown = start_cooldown ?? true;

			
			if ( Game13.time >= this.next_poltergeist ) {
				
				if ( start_cooldown == true ) {
					this.start_poltergeist_cooldown();
				}
				return true;
			}
			return false;
		}

		// Function from file: observer.dm
		public override bool Life(  ) {
			Image hud = null;
			ByTable target_list = null;
			Mob_Living target = null;

			
			if ( this.timestopped ) {
				return false;
			}
			base.Life();

			if ( !( this.loc != null ) ) {
				return false;
			}

			if ( !( this.client != null ) ) {
				return false;
			}

			if ( this.client.images.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.client.images, typeof(Image) )) {
					hud = _a;
					

					if ( String13.FindIgnoreCase( hud.icon_state, "hud", 1, 4 ) != 0 ) {
						this.client.images.Remove( hud );
					}
				}
			}

			if ( this.antagHUD ) {
				target_list = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInViewExcludeThis( null, this ), typeof(Mob_Living) )) {
					target = _b;
					

					if ( target.mind != null && ( Lang13.Bool( target.mind.special_role ) || target is Mob_Living_Silicon ) ) {
						target_list.Add( target );
					}
				}

				if ( target_list.len != 0 ) {
					this.assess_targets( target_list, this );
				}
			}

			if ( this.medHUD ) {
				this.process_medHUD( this );
			}

			if ( this.visible != null ) {
				
				if ( this.invisibility == 0 ) {
					((dynamic)this.visible).icon_state = "visible1";
				} else {
					((dynamic)this.visible).icon_state = "visible0";
				}
			}
			return false;
		}

		// Function from file: observer.dm
		public override dynamic get_multitool( bool? if_active = null ) {
			if_active = if_active ?? false;

			return this.ghostMulti;
		}

		// Function from file: observer.dm
		public override ByTable GetAccess(  ) {
			return ( GlobalFuncs.isAdminGhost( this ) ? GlobalFuncs.get_all_accesses() : new ByTable() );
		}

		// Function from file: observer.dm
		public override bool hasFullAccess(  ) {
			return GlobalFuncs.isAdminGhost( this );
		}

		// Function from file: observer.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.following = null;
			this.ghostMulti = null;
			this.canclone = null;
			GlobalVars.observers.Remove( this );
			return null;
		}

		// Function from file: login.dm
		public override dynamic MouseDrop( Mob over_object = null, dynamic src_location = null, Ent_Static over_location = null, dynamic src_control = null, dynamic over_control = null, string _params = null ) {
			
			if ( !( Task13.User != null ) || !( over_object != null ) ) {
				return null;
			}

			if ( Task13.User is Mob_Dead_Observer && Task13.User.client.holder != null && over_object is Mob_Living ) {
				
				if ( Task13.User.client.holder.cmd_ghost_drag( this, over_object ) ) {
					return null;
				}
			}
			return base.MouseDrop( over_object, (object)(src_location), over_location, (object)(src_control), (object)(over_control), _params );
		}

		// Function from file: observer.dm
		public override void ShiftClickOn( Ent_Static A = null ) {
			this.examination( A );
			return;
		}

		// Function from file: observer.dm
		public override bool ClickOn( Ent_Static A = null, string _params = null ) {
			ByTable modifiers = null;

			
			if ( this.client.buildmode != 0 ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return false;
			}

			if ( this.attack_delayer.blocked() ) {
				return false;
			}
			modifiers = String13.ParseUrlParams( _params );

			if ( Lang13.Bool( modifiers["middle"] ) ) {
				this.MiddleClickOn( A );
				return false;
			}

			if ( Lang13.Bool( modifiers["shift"] ) ) {
				this.ShiftClickOn( A );
				return false;
			}

			if ( Lang13.Bool( modifiers["alt"] ) ) {
				this.AltClickOn( A );
				return false;
			}

			if ( Lang13.Bool( modifiers["ctrl"] ) ) {
				this.CtrlClickOn( A );
				return false;
			}
			A.attack_ghost( this );
			return false;
		}

		// Function from file: observer.dm
		public override void DblClickOn( Ent_Static A = null, string _params = null ) {
			dynamic targetloc = null;
			dynamic targetarea = null;
			ByTable turfs = null;
			dynamic T = null;

			
			if ( this.client.buildmode != 0 ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return;
			}

			if ( this.can_reenter_corpse != 0 && this.mind != null && Lang13.Bool( this.mind.current ) ) {
				
				if ( A == this.mind.current || Lang13.Bool( ((dynamic)A).Contains( this.mind.current ) ) ) {
					this.reenter_corpse();
					return;
				}
			}

			if ( A is Mob && A != this || A is Obj_Machinery_Bot || A is Obj_Machinery_Singularity ) {
				this.manual_follow( A );
			} else {
				targetloc = GlobalFuncs.get_turf( A );
				targetarea = GlobalFuncs.get_area( A );

				if ( !Lang13.Bool( targetloc ) ) {
					
					if ( !Lang13.Bool( targetarea ) ) {
						return;
					}
					turfs = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( targetarea )) {
						T = _a;
						

						if ( T.density ) {
							continue;
						}
						turfs.Add( T );
					}
					targetloc = GlobalFuncs.pick_n_take( turfs );

					if ( !Lang13.Bool( targetloc ) ) {
						return;
					}
				}

				if ( Lang13.Bool( targetarea ) && targetarea.anti_ethereal && !GlobalFuncs.isAdminGhost( Task13.User ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='sinister'>A dark forcefield prevents you from entering the area.<span>" );
				} else if ( targetloc.holy && ( this.invisibility == 0 || Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( this.mind ) ) ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>These are sacred grounds, you cannot go there!</span>" );
				} else {
					this.forceEnter( targetloc );

					if ( Lang13.Bool( this.locked_to ) ) {
						this.manual_stop_follow( this.locked_to );
					}
				}
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Point To", group: "Object" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile )]
		public override bool pointed( dynamic A = null ) {
			
			if ( !Lang13.Bool( Lang13.SuperCall( A ) ) ) {
				return false;
			}
			Task13.User.visible_message( "<span class='deadsay'><b>" + this + "</b> points to " + A + "</span>" );
			return true;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Add Note", group: "IC", hidden: true )]
		public override void add_memory( string msg = null ) {
			GlobalFuncs.to_chat( this, "<span class='warning'>You are dead! You have no mind to store memory!</span>" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Notes", group: "IC", hidden: true )]
		public override void f_memory(  ) {
			GlobalFuncs.to_chat( this, "<span class='warning'>You are dead! You have no mind to store memory!</span>" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Search For Arenas", desc: "Try to find an Arena to polish your robust bomb placement skills..", group: "Ghost" )]
		public void find_arena(  ) {
			dynamic arena_target = null;

			
			if ( !( GlobalVars.arenas.len != 0 ) ) {
				GlobalFuncs.to_chat( Task13.User, "There are no arenas in the world! Ask the admins to spawn one." );
				return;
			}
			arena_target = Interface13.Input( "Which arena do you wish to reach?", "Arena Search Panel", null, null, GlobalVars.arenas, InputType.Any );
			GlobalFuncs.to_chat( Task13.User, "Reached " + arena_target );
			Task13.User.loc = arena_target.center;
			GlobalFuncs.to_chat( Task13.User, "Remember to enable darkness to be able to see the spawns. Click on a green spawn between rounds to register on it." );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Become MoMMI", group: "Ghost" )]
		public void become_mommi(  ) {
			double timedifference = 0;
			string timedifference_text = null;
			ByTable found_spawners = null;
			Obj_Machinery_MommiSpawner s = null;
			ByTable options = null;
			int? t = null;
			dynamic S = null;
			string dat = null;
			dynamic selection = null;
			int? i = null;
			Ent_Static final = null;

			
			if ( !GlobalVars.config.respawn_as_mommi ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>Respawning as MoMMI is disabled..</span>" );
				return;
			}
			timedifference = Game13.time - this.client.time_died_as_mouse;

			if ( this.client.time_died_as_mouse != 0 && timedifference <= 3000 ) {
				timedifference_text = String13.FormatTime( 3000 - timedifference, "mm:ss" );
				GlobalFuncs.to_chat( this, "<span class='warning'>You may only spawn again as a mouse or MoMMI more than " + 5 + " minutes after your death. You have " + timedifference_text + " left.</span>" );
				return;
			}
			found_spawners = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_MommiSpawner) )) {
				s = _a;
				

				if ( s.canSpawn() ) {
					found_spawners.Add( s );
				}
			}

			if ( found_spawners.len != 0 ) {
				options = null;
				options = new ByTable( found_spawners.len );
				t = null;
				t = 1;

				while (( t ??0) <= found_spawners.len) {
					S = found_spawners[t];
					dat = "" + GlobalFuncs.get_area( S ) + " on z-level = " + S.z;
					options[t] = dat;
					t++;
				}
				selection = Interface13.Input( this, "Select a MoMMI spawn location", "Become MoMMI", null, options, InputType.Null | InputType.Any );

				if ( Lang13.Bool( selection ) ) {
					i = null;
					i = 1;

					while (( i ??0) <= options.len) {
						
						if ( options[i] == selection ) {
							final = found_spawners[i];
							final.attack_ghost( this );
							break;
						}
						i++;
					}
				}
			} else {
				GlobalFuncs.to_chat( this, "<span class='warning'>Unable to find any MoMMI Spawners ready to build a MoMMI in the universe. Please try again.</span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Hide Sprite", group: "Ghost" )]
		public void hide_sprite(  ) {
			
			if ( this.alpha == 127 ) {
				this.alpha = 0;
				GlobalFuncs.to_chat( this, "<span class='warning'>Sprite hidden.</span>" );
			} else {
				this.alpha = 127;
				GlobalFuncs.to_chat( this, "<span class='info'>Sprite shown.</span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "View Crew Manifest", group: "Ghost" )]
		public void view_manfiest(  ) {
			dynamic dat = null;

			dat += "<h4>Crew Manifest</h4>";
			dat += GlobalVars.data_core.get_manifest();
			Interface13.Browse( this, dat, "window=manifest;size=370x420;can_close=1" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Become mouse", group: "Ghost" )]
		public void become_mouse(  ) {
			double timedifference = 0;
			string timedifference_text = null;
			string response = null;
			Mob_Living_SimpleAnimal_Mouse host = null;
			dynamic vent_found = null;
			ByTable found_vents = null;
			Obj_Machinery_Atmospherics_Unary_VentPump v = null;

			
			if ( !GlobalVars.config.respawn_as_mouse ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>Respawning as mouse is disabled..</span>" );
				return;
			}
			timedifference = Game13.time - this.client.time_died_as_mouse;

			if ( this.client.time_died_as_mouse != 0 && timedifference <= 3000 ) {
				timedifference_text = String13.FormatTime( 3000 - timedifference, "mm:ss" );
				GlobalFuncs.to_chat( this, "<span class='warning'>You may only spawn again as a mouse more than " + 5 + " minutes after your death. You have " + timedifference_text + " left.</span>" );
				return;
			}
			response = Interface13.Alert( this, "Are you -sure- you want to become a mouse?", "Are you sure you want to squeek?", "Squeek!", "Nope!" );

			if ( response != "Squeek!" ) {
				return;
			}
			found_vents = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.atmos_machines, typeof(Obj_Machinery_Atmospherics_Unary_VentPump) )) {
				v = _a;
				

				if ( !v.welded && v.z == this.z && v.canSpawnMice ) {
					found_vents.Add( v );
				}
			}

			if ( found_vents.len != 0 ) {
				vent_found = Rand13.PickFromTable( found_vents );
				host = new Mob_Living_SimpleAnimal_Mouse( vent_found.loc );
			} else {
				GlobalFuncs.to_chat( this, "<span class='warning'>Unable to find any unwelded vents to spawn mice at.</span>" );
			}

			if ( host != null ) {
				
				if ( GlobalVars.config.uneducated_mice ) {
					host.universal_understand = false;
				}
				host.ckey = this.ckey;
				GlobalFuncs.to_chat( host, "<span class='info'>You are now a mouse. Try to avoid interaction with players, and do not give hints away that you are more than a simple rodent.</span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle Darkness", group: "Ghost" )]
		public void toggle_darkness(  ) {
			
			if ( this.see_invisible == 15 ) {
				this.see_invisible = 60;
			} else {
				this.see_invisible = 15;
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Analyze Air", group: "Ghost" )]
		public void analyze_air(  ) {
			GasMixture environment = null;
			dynamic pressure = null;
			dynamic total_moles = null;
			dynamic o2_concentration = null;
			dynamic n2_concentration = null;
			dynamic co2_concentration = null;
			dynamic plasma_concentration = null;
			double unknown_concentration = 0;

			
			if ( !( Task13.User is Mob_Dead_Observer ) ) {
				return;
			}

			if ( !( Task13.User.loc is Tile ) ) {
				return;
			}
			environment = Task13.User.loc.return_air();
			pressure = environment.return_pressure();
			total_moles = environment.f_total_moles();
			GlobalFuncs.to_chat( this, "<span class='notice'><B>Results:</B></span>" );

			if ( Math.Abs( Convert.ToDouble( pressure - 101.32499694824219 ) ) < 10 ) {
				GlobalFuncs.to_chat( this, "<span class='notice'>Pressure: " + Num13.Round( Convert.ToDouble( pressure ), 0.1 ) + " kPa</span>" );
			} else {
				GlobalFuncs.to_chat( this, "<span class='warning'>Pressure: " + Num13.Round( Convert.ToDouble( pressure ), 0.1 ) + " kPa</span>" );
			}

			if ( Lang13.Bool( total_moles ) ) {
				o2_concentration = environment.oxygen / total_moles;
				n2_concentration = environment.nitrogen / total_moles;
				co2_concentration = environment.carbon_dioxide / total_moles;
				plasma_concentration = environment.toxins / total_moles;
				unknown_concentration = 1 - Convert.ToDouble( o2_concentration + n2_concentration + co2_concentration + plasma_concentration );

				if ( Math.Abs( Convert.ToDouble( n2_concentration - 0.79 ) ) < 20 ) {
					GlobalFuncs.to_chat( this, "<span class='notice'>Nitrogen: " + Num13.Floor( Convert.ToDouble( n2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.nitrogen ), 0.01 ) + " moles)</span>" );
				} else {
					GlobalFuncs.to_chat( this, "<span class='warning'>Nitrogen: " + Num13.Floor( Convert.ToDouble( n2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.nitrogen ), 0.01 ) + " moles)</span>" );
				}

				if ( Math.Abs( Convert.ToDouble( o2_concentration - 0.01 ) ) < 2 ) {
					GlobalFuncs.to_chat( this, "<span class='notice'>Oxygen: " + Num13.Floor( Convert.ToDouble( o2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.oxygen ), 0.01 ) + " moles)</span>" );
				} else {
					GlobalFuncs.to_chat( this, "<span class='warning'>Oxygen: " + Num13.Floor( Convert.ToDouble( o2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.oxygen ), 0.01 ) + " moles)</span>" );
				}

				if ( Convert.ToDouble( co2_concentration ) > 0.01 ) {
					GlobalFuncs.to_chat( this, "<span class='warning'>CO2: " + Num13.Floor( Convert.ToDouble( co2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.carbon_dioxide ), 0.01 ) + " moles)</span>" );
				} else {
					GlobalFuncs.to_chat( this, "<span class='notice'>CO2: " + Num13.Floor( Convert.ToDouble( co2_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.carbon_dioxide ), 0.01 ) + " moles)</span>" );
				}

				if ( Convert.ToDouble( plasma_concentration ) > 0.01 ) {
					GlobalFuncs.to_chat( this, "<span class='warning'>Plasma: " + Num13.Floor( Convert.ToDouble( plasma_concentration * 100 ) ) + "% (" + Num13.Round( Convert.ToDouble( environment.toxins ), 0.01 ) + " moles)</span>" );
				}

				if ( unknown_concentration > 0.01 ) {
					GlobalFuncs.to_chat( this, "<span class='warning'>Unknown: " + Num13.Floor( unknown_concentration * 100 ) + "% (" + Num13.Round( unknown_concentration * Convert.ToDouble( total_moles ), 0.01 ) + " moles)</span>" );
				}
				GlobalFuncs.to_chat( this, "<span class='notice'>Temperature: " + Num13.Round( ( environment.temperature ??0) - 273.41, 0.1 ) + "&deg;C</span>" );
				GlobalFuncs.to_chat( this, "<span class='notice'>Heat Capacity: " + Num13.Round( environment.heat_capacity(), 0.1 ) + "</span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Jump to Mob", desc: "Teleport to a mob", group: "Ghost" )]
		public void jumptomob(  ) {
			ByTable dest = null;
			dynamic target = null;
			dynamic targetloc = null;
			dynamic targetarea = null;
			dynamic M = null;
			Mob_Dead_Observer A = null;
			dynamic T = null;

			
			if ( Task13.User is Mob_Dead_Observer ) {
				dest = new ByTable();
				target = null;
				dest.Add( GlobalFuncs.getmobs() );
				target = Interface13.Input( "Please, select a player!", "Jump to Mob", null, null, dest, InputType.Null | InputType.Any );

				if ( !Lang13.Bool( target ) ) {
					return;
				} else {
					targetloc = GlobalFuncs.get_turf( target );
					targetarea = GlobalFuncs.get_area( target );

					if ( Lang13.Bool( targetarea ) && targetarea.anti_ethereal && !GlobalFuncs.isAdminGhost( Task13.User ) ) {
						GlobalFuncs.to_chat( Task13.User, "<span class='sinister'>You can sense a sinister force surrounding that mob, your spooky body itself refuses to jump to it.</span>" );
						return;
					}

					if ( Lang13.Bool( targetloc ) && targetloc.holy && ( this.invisibility == 0 || Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( this.mind ) ) ) ) {
						GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The mob that you are trying to follow is standing on holy grounds, you cannot reach him!</span>" );
						return;
					}
					M = dest[target];
					A = this;
					T = GlobalFuncs.get_turf( M );

					if ( Lang13.Bool( T ) && T is Tile ) {
						A.loc = T;

						if ( Lang13.Bool( this.locked_to ) ) {
							this.manual_stop_follow( this.locked_to );
						}
					} else {
						GlobalFuncs.to_chat( A, "This mob is not located in the game world." );
					}
				}
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Stop Haunting", desc: "Stop haunting a mob. They weren't worth your eternal time anyways.", group: "Ghost" )]
		public void end_follow(  ) {
			
			if ( Lang13.Bool( this.locked_to ) ) {
				this.manual_stop_follow( this.locked_to );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Haunt", desc: "Haunt a mob, stalking them everywhere they go.", group: "Ghost" )]
		public void follow(  ) {
			ByTable mobs = null;
			dynamic input = null;
			dynamic target = null;

			mobs = GlobalFuncs.getmobs();
			input = Interface13.Input( "Please, select a mob!", "Haunt", null, null, mobs, InputType.Null | InputType.Any );
			target = mobs[input];
			this.manual_follow( target );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle AntagHUD", desc: "Toggles AntagHUD allowing you to see who is the antagonist", group: "Ghost" )]
		public void toggle_antagHUD(  ) {
			Mob_Dead_Observer M = null;
			string response = null;

			
			if ( !GlobalVars.config.antag_hud_allowed && !( this.client.holder != null ) ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>Admins have disabled this for this round.</span>" );
				return;
			}

			if ( !( this.client != null ) ) {
				return;
			}
			M = this;

			if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( M, "AntagHUD" ) ) ) {
				GlobalFuncs.to_chat( this, "<span class='danger'>You have been banned from using this feature.</span>" );
				return;
			}

			if ( GlobalVars.config.antag_hud_restricted && !( M.has_enabled_antagHUD != 0 ) && !( this.client.holder != null ) ) {
				response = Interface13.Alert( this, "If you turn this on, you will not be able to take any part in the round.", "Are you sure you want to turn this feature on?", "Yes", "No" );

				if ( response == "No" ) {
					return;
				}
				M.can_reenter_corpse = 0;
			}

			if ( !( M.has_enabled_antagHUD != 0 ) && !( this.client.holder != null ) ) {
				M.has_enabled_antagHUD = 1;
			}

			if ( M.antagHUD ) {
				M.antagHUD = false;
				GlobalFuncs.to_chat( this, "<span class='notice'><B>AntagHUD Disabled</B></span>" );
			} else {
				M.antagHUD = true;
				GlobalFuncs.to_chat( this, "<span class='notice'><B>AntagHUD Enabled</B></span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle MedicHUD", desc: "Toggles Medical HUD allowing you to see how everyone is doing", group: "Ghost" )]
		public void toggle_medHUD(  ) {
			
			if ( !( this.client != null ) ) {
				return;
			}

			if ( this.medHUD ) {
				this.medHUD = false;
				GlobalFuncs.to_chat( this, "<span class='notice'><B>Medical HUD Disabled</B></span>" );
			} else {
				this.medHUD = true;
				GlobalFuncs.to_chat( this, "<span class='notice'><B>Medical HUD Enabled</B></span>" );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Re-enter Corpse", group: "Ghost" )]
		public bool reenter_corpse(  ) {
			Obj_Effect_Rune R = null;

			
			if ( !( this.client != null ) ) {
				return false;
			}

			if ( !( this.mind != null && Lang13.Bool( this.mind.current ) && this.can_reenter_corpse != 0 ) ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You have no body.</span>" );
				return false;
			}

			if ( Lang13.Bool( this.mind.current.key ) && String13.SubStr( this.mind.current.key, 1, 2 ) != "@" ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Another consciousness is in your body...It is resisting you.</span>" );
				return false;
			}

			if ( Lang13.Bool( this.mind.current.ajourn ) && Convert.ToInt32( this.mind.current.stat ) != 2 ) {
				R = this.mind.current.ajourn;

				if ( !( R != null && R.word1 == GlobalVars.cultwords["hell"] && R.word2 == GlobalVars.cultwords["travel"] && R.word3 == GlobalVars.cultwords["self"] ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The astral cord that ties your body and your spirit has been severed. You are likely to wander the realm beyond until your body is finally dead and thus reunited with you.</span>" );
					return false;
				}
			}

			if ( this.mind != null && Lang13.Bool( this.mind.current ) && Lang13.Bool( this.mind.current.ajourn ) ) {
				this.mind.current.ajourn.ajourn = null;
				this.mind.current.ajourn = null;
			}
			this.mind.current.key = this.key;
			this.mind.isScrying = false;
			return true;
		}

	}

}