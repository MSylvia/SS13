// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_HolodeckControl : Obj_Machinery_Computer {

		public dynamic linkedholodeck = null;
		public dynamic target = null;
		public bool active = false;
		public dynamic holographic_items = new ByTable();
		public bool damaged = false;
		public int last_change = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.light_color = "#7DE1E1";
			this.icon_state = "holocontrol";
		}

		// Function from file: HolodeckControl.dm
		public Obj_Machinery_Computer_HolodeckControl ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.linkedholodeck = Lang13.FindObj( typeof(Zone_Holodeck_Alphadeck) );
			return;
		}

		// Function from file: HolodeckControl.dm
		public void emergencyShutdown(  ) {
			dynamic item = null;
			dynamic targetsource = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.holographic_items )) {
				item = _a;
				
				this.derez( item );
			}
			this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourcePlating) );

			if ( Lang13.Bool( this.target ) ) {
				this.loadProgram( this.target );
			}
			targetsource = Lang13.FindObj( typeof(Zone_Holodeck_SourcePlating) );
			((Zone)targetsource).copy_contents_to( this.linkedholodeck, true );
			this.active = false;
			return;
		}

		// Function from file: HolodeckControl.dm
		public void loadProgram( dynamic A = null ) {
			dynamic M = null;
			dynamic item = null;
			Obj_Effect_Decal_Cleanable_Blood B = null;
			Mob_Living_SimpleAnimal_Hostile_Carp_Holocarp holocarp = null;
			Obj_Item_Weapon_Holo_Esword H = null;
			Obj_Effect_Landmark L = null;
			dynamic T = null;
			Effect_Effect_System_SparkSpread s = null;

			
			if ( Game13.time < this.last_change + 25 ) {
				
				if ( Game13.time < this.last_change + 15 ) {
					return;
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 3 ) )) {
					M = _a;
					
					M.show_message( "<B>ERROR. Recalibrating projetion apparatus.</B>" );
					this.last_change = Game13.time;
					return;
				}
			}
			this.last_change = Game13.time;
			this.active = true;

			foreach (dynamic _b in Lang13.Enumerate( this.holographic_items )) {
				item = _b;
				
				this.derez( item );
			}

			foreach (dynamic _c in Lang13.Enumerate( this.linkedholodeck, typeof(Obj_Effect_Decal_Cleanable_Blood) )) {
				B = _c;
				
				GlobalFuncs.returnToPool( B );
			}

			foreach (dynamic _d in Lang13.Enumerate( this.linkedholodeck, typeof(Mob_Living_SimpleAnimal_Hostile_Carp_Holocarp) )) {
				holocarp = _d;
				
				GlobalFuncs.qdel( holocarp );
			}
			this.holographic_items = ((Zone)A).copy_contents_to( this.linkedholodeck, true );

			if ( this.emagged != 0 ) {
				
				foreach (dynamic _e in Lang13.Enumerate( this.linkedholodeck, typeof(Obj_Item_Weapon_Holo_Esword) )) {
					H = _e;
					
					H.damtype = "brute";
				}
			}
			Task13.Schedule( 30, (Task13.Closure)(() => {
				
				foreach (dynamic _f in Lang13.Enumerate( this.linkedholodeck, typeof(Obj_Effect_Landmark) )) {
					L = _f;
					

					if ( L.name == "Atmospheric Test Start" ) {
						Task13.Schedule( 20, (Task13.Closure)(() => {
							T = GlobalFuncs.get_turf( L );
							s = new Effect_Effect_System_SparkSpread();
							s.set_up( 2, 1, T );
							s.start();

							if ( Lang13.Bool( T ) ) {
								T.temperature = 5000;
								((Tile)T).hotspot_expose( 50000, 50000, true, true );
							}
							return;
						}));
					}

					if ( L.name == "Holocarp Spawn" ) {
						new Mob_Living_SimpleAnimal_Hostile_Carp_Holocarp( L.loc );
					}
				}
				return;
			}));
			return;
		}

		// Function from file: HolodeckControl.dm
		public void togglePower( bool? toggleOn = null ) {
			toggleOn = toggleOn ?? false;

			dynamic targetsource = null;
			Obj_Effect_Landmark L = null;
			dynamic T = null;
			Effect_Effect_System_SparkSpread s = null;
			dynamic item = null;
			dynamic targetsource2 = null;

			
			if ( toggleOn == true ) {
				targetsource = Lang13.FindObj( typeof(Zone_Holodeck_SourceEmptycourt) );
				this.holographic_items = ((Zone)targetsource).copy_contents_to( this.linkedholodeck );
				Task13.Schedule( 30, (Task13.Closure)(() => {
					
					foreach (dynamic _a in Lang13.Enumerate( this.linkedholodeck, typeof(Obj_Effect_Landmark) )) {
						L = _a;
						

						if ( L.name == "Atmospheric Test Start" ) {
							Task13.Schedule( 20, (Task13.Closure)(() => {
								T = GlobalFuncs.get_turf( L );
								s = new Effect_Effect_System_SparkSpread();
								s.set_up( 2, 1, T );
								s.start();

								if ( Lang13.Bool( T ) ) {
									T.temperature = 5000;
									((Tile)T).hotspot_expose( 50000, 50000, true, true );
								}
								return;
							}));
						}
					}
					return;
				}));
				this.active = true;
			} else {
				
				foreach (dynamic _b in Lang13.Enumerate( this.holographic_items )) {
					item = _b;
					
					this.derez( item );
				}
				targetsource2 = Lang13.FindObj( typeof(Zone_Holodeck_SourcePlating) );
				((Zone)targetsource2).copy_contents_to( this.linkedholodeck, true );
				this.active = false;
			}
			return;
		}

		// Function from file: HolodeckControl.dm
		public bool checkInteg( dynamic A = null ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( A )) {
				T = _a;
				

				if ( T is Tile_Space ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: HolodeckControl.dm
		public void derez( dynamic obj = null, bool? silent = null ) {
			silent = silent ?? true;

			Ent_Static M = null;
			dynamic oldobj = null;

			this.holographic_items.Remove( obj );

			if ( obj == null ) {
				return;
			}

			if ( obj is Obj ) {
				M = obj.loc;

				if ( M is Mob ) {
					((Mob)M).u_equip( obj, false );
					((dynamic)M).update_icons();
				}
			}

			if ( !( silent == true ) ) {
				oldobj = obj;
				this.visible_message( "The " + oldobj.name + " fades away!" );
			}
			GlobalFuncs.qdel( obj );
			return;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic process(  ) {
			dynamic item = null;
			dynamic M = null;
			dynamic T = null;
			Effect_Effect_System_SparkSpread s = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.holographic_items )) {
				item = _a;
				

				if ( !Lang13.Bool( this.linkedholodeck.Contains( GlobalFuncs.get_turf( item ) ) ) ) {
					this.derez( item, false );
				}
			}

			if ( !Lang13.Bool( base.process() ) ) {
				return null;
			}

			if ( this.active ) {
				
				if ( !this.checkInteg( this.linkedholodeck ) ) {
					this.damaged = true;
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourcePlating) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
					this.active = false;

					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( this, 10 ) )) {
						M = _b;
						
						M.show_message( "The holodeck overloads!" );
					}

					foreach (dynamic _c in Lang13.Enumerate( this.linkedholodeck )) {
						T = _c;
						

						if ( Rand13.PercentChance( 30 ) ) {
							s = new Effect_Effect_System_SparkSpread();
							s.set_up( 2, 1, T );
							s.start();
						}
						((Ent_Static)T).ex_act( 3 );
						((Tile)T).hotspot_expose( 1000, 500, true, true );
					}
				}
			}
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override bool blob_act( dynamic severity = null ) {
			this.emergencyShutdown();
			base.blob_act( (object)(severity) );
			return false;
		}

		// Function from file: HolodeckControl.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.emergencyShutdown();
			base.ex_act( severity, (object)(child) );
			return false;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic emp_act( int severity = 0 ) {
			this.emergencyShutdown();
			base.emp_act( severity );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.emergencyShutdown();
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override int emag( dynamic user = null ) {
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/sparks4.ogg", 75, 1 );

			if ( this.emagged != 0 ) {
				return 0;
			}
			this.emagged = 1;
			this.visible_message( "<span class='warning'>" + user + " swipes a card into the holodeck reader.</span>", "<span class='notice'>You swipe the electromagnetic card into the holocard reader.</span>" );
			this.visible_message( "<span class='warning'>Warning: Power surge detected. Automatic shutoff and derezing protocols have been corrupted. Please contact Nanotrasen maintenance and cease all operation immediately.</span>" );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name( Task13.User ) + " emagged the Holodeck Control Computer" ) ) );
			this.updateUsrDialog();
			return 0;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			} else {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["emptycourt"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceEmptycourt) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["boxingcourt"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceBoxingcourt) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["basketball"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceBasketball) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["thunderdomecourt"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceThunderdomecourt) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["beach"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceBeach) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["desert"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceDesert) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["space"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceSpace) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["picnicarea"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourcePicnicarea) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["snowfield"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceSnowfield) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["theatre"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceTheatre) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["meetinghall"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceMeetinghall) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["turnoff"] ) ) {
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourcePlating) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["burntest"] ) ) {
					
					if ( !( this.emagged != 0 ) ) {
						return null;
					}
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceBurntest) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["wildlifecarp"] ) ) {
					
					if ( !( this.emagged != 0 ) ) {
						return null;
					}
					this.target = Lang13.FindObj( typeof(Zone_Holodeck_SourceWildlife) );

					if ( Lang13.Bool( this.target ) ) {
						this.loadProgram( this.target );
					}
				} else if ( Lang13.Bool( href_list["AIoverride"] ) ) {
					
					if ( !( Task13.User is Mob_Living_Silicon ) ) {
						return null;
					}
					this.emagged = !( this.emagged != 0 ) ?1:0;

					if ( this.emagged != 0 ) {
						GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Task13.User ) + " overrode the holodeck's safeties" );
						GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name( Task13.User ) + " overrided the holodeck's safeties" ) ) );
						this.visible_message( "<span class='warning'>Warning: Holodeck safeties overriden. Please contact Nanotrasen maintenance and cease all operation if you are not source of that command.</span>" );
					} else {
						GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Task13.User ) + " restored the holodeck's safeties" );
						GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name( Task13.User ) + " restored the holodeck's safeties" ) ) );
						this.visible_message( "<span class='notice'>Holodeck safeties have been restored. Simulation programs are now safe to use again.</span>" );
					}
				}
				this.add_fingerprint( Task13.User );
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic dat = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			((Mob)a).set_machine( this );
			dat += new Txt( "<B>Holodeck Control System</B><BR>\n		<HR>Current Loaded Programs:<BR>\n		<A href='?src=" ).Ref( this ).str( ";emptycourt=1'>((Empty Court)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";boxingcourt=1'>((Boxing Court)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";basketball=1'>((Basketball Court)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";thunderdomecourt=1'>((Thunderdome Court)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";beach=1'>((Beach)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";desert=1'>((Desert)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";space=1'>((Space)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";picnicarea=1'>((Picnic Area)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";snowfield=1'>((Snow Field)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";theatre=1'>((Theatre)</font>)</A><BR>\n		<A href='?src=" ).Ref( this ).str( ";meetinghall=1'>((Meeting Hall)</font>)</A><BR>" ).ToString();
			dat += "Please ensure that only holographic weapons are used in the holodeck if a combat simulation has been loaded.<BR>";

			if ( this.emagged != 0 ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";burntest=1'>(<font color=red>Begin Atmospheric Burn Simulation</font>)</A><BR>\n			Ensure the holodeck is empty before testing.<BR>\n			<BR>\n			<A href='?src=" ).Ref( this ).str( ";wildlifecarp=1'>(<font color=red>Begin Wildlife Simulation</font>)</A><BR>\n			Ensure the holodeck is empty before testing.<BR>\n			<BR>" ).ToString();

				if ( a is Mob_Living_Silicon ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";AIoverride=1'>(<font color=green>Re-Enable Safety Protocols?</font>)</A><BR>" ).ToString();
				}
				dat += "Safety Protocols are <font color=red> DISABLED </font><BR>";
			} else {
				
				if ( a is Mob_Living_Silicon ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";AIoverride=1'>(<font color=red>Override Safety Protocols?</font>)</A><BR>" ).ToString();
				}
				dat += "<BR>\n			Safety Protocols are <font color=green> ENABLED </font><BR>";
			}
			Interface13.Browse( a, dat, "window=computer;size=400x500" );
			GlobalFuncs.onclose( a, "computer" );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}