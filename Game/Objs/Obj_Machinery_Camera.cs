// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Camera : Obj_Machinery {

		public dynamic health = 50;
		public ByTable network = new ByTable(new object [] { "SS13" });
		public dynamic c_tag = null;
		public int c_tag_order = 999;
		public bool status = true;
		public bool start_active = false;
		public dynamic invuln = null;
		public dynamic bug = null;
		public Obj_Machinery_CameraAssembly assembly = null;
		public dynamic view_range = 7;
		public int short_range = 2;
		public bool alarm_on = false;
		public bool busy = false;
		public int emped = 0;
		public int upgrades = 0;
		public ByTable motionTargets = new ByTable();
		public int detectTime = 0;
		public Zone_AiMonitored area_motion = null;
		public int alarm_delay = 30;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 2;
			this.idle_power_usage = 5;
			this.active_power_usage = 10;
			this.anchored = 1;
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "camera";
			this.layer = 5;
		}

		// Function from file: camera.dm
		public Obj_Machinery_Camera ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.assembly = new Obj_Machinery_CameraAssembly( this );
			this.assembly.state = 4;
			GlobalVars.cameranet.cameras.Add( this );
			GlobalVars.cameranet.addCamera( this );
			GlobalFuncs.add_to_proximity_list( this, 1 );
			return;
		}

		// Function from file: tracking.dm
		public override dynamic attack_ai( dynamic user = null ) {
			
			if ( !( user is Mob_Living_Silicon_Ai ) ) {
				return null;
			}

			if ( !this.can_use() ) {
				return null;
			}
			((Mob_Camera_AiEye)user.eyeobj).setLoc( GlobalFuncs.get_turf( this ) );
			return null;
		}

		// Function from file: motion.dm
		public override bool HasProximity( dynamic AM = null ) {
			
			if ( !( this.area_motion != null ) ) {
				
				if ( AM is Mob_Living ) {
					this.newTarget( AM );
				}
			}
			return false;
		}

		// Function from file: motion.dm
		public override int? process( dynamic seconds = null ) {
			int? _default = null;

			int elapsed = 0;
			dynamic target = null;

			
			if ( !( this.isMotion() != 0 ) ) {
				_default = 26;
				return _default;
			}

			if ( this.detectTime > 0 ) {
				elapsed = Game13.time - this.detectTime;

				if ( elapsed > this.alarm_delay ) {
					this.triggerAlarm();
				}
			} else if ( this.detectTime == -1 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.motionTargets )) {
					target = _a;
					

					if ( Convert.ToInt32( target.stat ) == 2 ) {
						this.lostTarget( target );
					}

					if ( !( this.area_motion != null ) ) {
						
						if ( !( Map13.GetDistance( this, target ) <= 1 ) ) {
							this.lostTarget( target );
						}
					}
				}
			}
			return _default;
		}

		// Function from file: camera.dm
		public override dynamic Destroy(  ) {
			this.toggle_cam( null, false );

			if ( this.assembly != null ) {
				GlobalFuncs.qdel( this.assembly );
				this.assembly = null;
			}

			if ( this.bug is Obj_Item_Device_CameraBug ) {
				this.bug.bugged_cameras.Remove( this.c_tag );

				if ( this.bug.current == this ) {
					this.bug.current = null;
				}
				this.bug = null;
			}
			GlobalVars.cameranet.removeCamera( this );
			GlobalVars.cameranet.cameras.Remove( this );
			GlobalVars.cameranet.removeCamera( this );
			return base.Destroy();
		}

		// Function from file: motion.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			GlobalFuncs.remove_from_proximity_list( this, 1 );
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			return false;
		}

		// Function from file: camera.dm
		public override bool update_remote_sight( Mob user = null ) {
			user.see_invisible = 25;

			if ( this.isXRay() != 0 ) {
				user.sight |= 28;
				user.see_in_dark = Num13.MaxInt( user.see_in_dark, 8 );
			} else {
				user.sight = 0;
				user.see_in_dark = 2;
			}
			return true;
		}

		// Function from file: camera.dm
		public override void get_remote_view_fullscreens( Mob_Living user = null ) {
			
			if ( this.view_range == this.short_range ) {
				user.overlay_fullscreen( "remote_view", typeof(Obj_Screen_Fullscreen_Impaired), 2 );
			}
			return;
		}

		// Function from file: camera.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( P.damage_type == "brute" ) {
				this.health = Num13.MaxInt( 0, Convert.ToInt32( this.health - P.damage ) );

				if ( !Lang13.Bool( this.health ) && this.status ) {
					this.triggerCameraAlarm();
					this.toggle_cam( null, true );
				}
			}
			return null;
		}

		// Function from file: camera.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			string msg = null;
			string msg2 = null;
			dynamic U = null;
			dynamic X = null;
			dynamic P = null;
			string itemname = null;
			dynamic info = null;
			dynamic O = null;
			dynamic AI = null;
			dynamic L = null;

			msg = "<span class='notice'>You attach " + A + " into the assembly's inner circuits.</span>";
			msg2 = "<span class='notice'>" + this + " already has that upgrade!</span>";

			if ( A is Obj_Item_Weapon_Screwdriver ) {
				this.panel_open = !Lang13.Bool( this.panel_open ) ?1:0;
				user.WriteMsg( "<span class='notice'>You screw the camera's panel " + ( Lang13.Bool( this.panel_open ) ? "open" : "closed" ) + ".</span>" );
				GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );
				return null;
			}

			if ( Lang13.Bool( this.panel_open ) ) {
				
				if ( A is Obj_Item_Weapon_Wirecutters ) {
					this.toggle_cam( user, true );
					this.health = Lang13.Initial( this, "health" );
				} else if ( A is Obj_Item_Device_Multitool ) {
					this.setViewRange( ( this.view_range == Lang13.Initial( this, "view_range" ) ? ((dynamic)( this.short_range )) : Lang13.Initial( this, "view_range" ) ) );
					user.WriteMsg( "<span class='notice'>You " + ( this.view_range == Lang13.Initial( this, "view_range" ) ? "restore" : "mess up" ) + " the camera's focus.</span>" );
				} else if ( A is Obj_Item_Weapon_Weldingtool ) {
					
					if ( this.weld( A, user ) ) {
						this.visible_message( "<span class='warning'>" + user + " unwelds " + this + ", leaving it as just a frame screwed to the wall.</span>", "<span class='warning'>You unweld " + this + ", leaving it as just a frame screwed to the wall</span>" );

						if ( !( this.assembly != null ) ) {
							this.assembly = new Obj_Machinery_CameraAssembly();
						}
						this.assembly.loc = this.loc;
						this.assembly.state = 1;
						this.assembly.dir = this.dir;
						this.assembly = null;
						GlobalFuncs.qdel( this );
						return null;
					}
				} else if ( A is Obj_Item_Device_Analyzer ) {
					
					if ( !( this.isXRay() != 0 ) ) {
						this.upgradeXRay();
						GlobalFuncs.qdel( A );
						user.WriteMsg( "" + msg );
					} else {
						user.WriteMsg( "" + msg2 );
					}
				} else if ( A is Obj_Item_Stack_Sheet_Mineral_Plasma ) {
					
					if ( !( this.isEmpProof() != 0 ) ) {
						this.upgradeEmpProof();
						user.WriteMsg( "" + msg );
						GlobalFuncs.qdel( A );
					} else {
						user.WriteMsg( "" + msg2 );
					}
				} else if ( A is Obj_Item_Device_Assembly_ProxSensor ) {
					
					if ( !( this.isMotion() != 0 ) ) {
						this.upgradeMotion();
						user.WriteMsg( "" + msg );
						GlobalFuncs.qdel( A );
					} else {
						user.WriteMsg( "" + msg2 );
					}
				}
			}

			if ( ( A is Obj_Item_Weapon_Paper || A is Obj_Item_Device_Pda ) && user is Mob_Living ) {
				U = user;
				X = null;
				P = null;
				itemname = "";
				info = "";

				if ( A is Obj_Item_Weapon_Paper ) {
					X = A;
					itemname = X.name;
					info = X.info;
				} else {
					P = A;
					itemname = P.name;
					info = P.notehtml;
				}
				U.WriteMsg( new Txt( "<span class='notice'>You hold " ).the( itemname ).item().str( " up to the camera...</span>" ).ToString() );
				((Mob)U).changeNext_move( 8 );

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
					O = _a;
					

					if ( O is Mob_Living_Silicon_Ai ) {
						AI = O;

						if ( AI.control_disabled || Convert.ToInt32( AI.stat ) == 2 ) {
							return null;
						}

						if ( U.name == "Unknown" ) {
							AI.WriteMsg( new Txt( "<b>" ).item( U ).str( "</b> holds <a href='?_src_=usr;show_paper=1;'>" ).a( itemname ).item().str( "</a> up to one of your cameras ..." ).ToString() );
						} else {
							AI.WriteMsg( new Txt( "<b><a href='?src=" ).Ref( AI ).str( ";track=" ).item( String13.HtmlEncode( U.name ) ).str( "'>" ).item( U ).str( "</a></b> holds <a href='?_src_=usr;show_paper=1;'>" ).a( itemname ).item().str( "</a> up to one of your cameras ..." ).ToString() );
						}
						AI.last_paper_seen = "<HTML><HEAD><TITLE>" + itemname + "</TITLE></HEAD><BODY><TT>" + info + "</TT></BODY></HTML>";
					} else if ( Lang13.Bool( O.client ) && O.client.eye == this ) {
						O.WriteMsg( new Txt().item( U ).str( " holds " ).a( itemname ).item().str( " up to one of the cameras ..." ).ToString() );
						Interface13.Browse( O, "<HTML><HEAD><TITLE>" + itemname + "</TITLE></HEAD><BODY><TT>" + info + "</TT></BODY></HTML>", "window=" + itemname );
					}
				}
			} else if ( A is Obj_Item_Device_CameraBug ) {
				
				if ( !this.can_use() ) {
					user.WriteMsg( "<span class='notice'>Camera non-functional.</span>" );
					return null;
				}

				if ( this.bug is Obj_Item_Device_CameraBug ) {
					user.WriteMsg( "<span class='notice'>Camera bug removed.</span>" );
					this.bug.bugged_cameras.Remove( this.c_tag );
					this.bug = null;
				} else {
					user.WriteMsg( "<span class='notice'>Camera bugged.</span>" );
					this.bug = A;
					this.bug.bugged_cameras[this.c_tag] = this;
				}
			} else if ( A is Obj_Item_Device_LaserPointer ) {
				L = A;
				((Obj_Item_Device_LaserPointer)L).laser_act( this, user );
			} else if ( Convert.ToDouble( A.force ) >= 10 ) {
				((Mob)user).changeNext_move( 8 );
				this.visible_message( "<span class='warning'>" + user + " hits " + this + " with " + A + "!</span>", "<span class='warning'>You hit " + this + " with " + A + "!</span>" );
				this.health = Num13.MaxInt( 0, Convert.ToInt32( this.health - A.force ) );
				((Ent_Dynamic)user).do_attack_animation( this );

				if ( !Lang13.Bool( this.health ) && this.status ) {
					this.triggerCameraAlarm();
					this.toggle_cam( user, true );
				}
			}
			return null;
		}

		// Function from file: camera.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( !( a is Mob_Living_Carbon_Alien_Humanoid ) ) {
				return null;
			}
			((Ent_Dynamic)a).do_attack_animation( this );
			this.add_hiddenprint( a );
			this.visible_message( new Txt( "<span class='warning'>" ).The( a ).item().str( " slashes at " ).item( this ).str( "!</span>" ).ToString() );
			GlobalFuncs.playsound( this.loc, "sound/weapons/slash.ogg", 100, 1 );
			this.health = Num13.MaxInt( 0, Convert.ToInt32( this.health - 30 ) );

			if ( !Lang13.Bool( this.health ) && this.status ) {
				this.toggle_cam( a, false );
			}
			return null;
		}

		// Function from file: presets.dm
		public void upgradeMotion(  ) {
			this.assembly.upgrades.Add( new Obj_Item_Device_Assembly_ProxSensor( this.assembly ) );
			this.upgrades |= 4;
			return;
		}

		// Function from file: presets.dm
		public void upgradeXRay(  ) {
			this.assembly.upgrades.Add( new Obj_Item_Device_Analyzer( this.assembly ) );
			this.upgrades |= 1;
			return;
		}

		// Function from file: presets.dm
		public void upgradeEmpProof(  ) {
			this.assembly.upgrades.Add( new Obj_Item_Stack_Sheet_Mineral_Plasma( this.assembly ) );
			this.upgrades |= 2;
			return;
		}

		// Function from file: presets.dm
		public int isMotion(  ) {
			return this.upgrades & 4;
		}

		// Function from file: presets.dm
		public int isXRay(  ) {
			return this.upgrades & 1;
		}

		// Function from file: presets.dm
		public int isEmpProof(  ) {
			return this.upgrades & 2;
		}

		// Function from file: motion.dm
		public bool triggerAlarm(  ) {
			Mob_Living_Silicon aiPlayer = null;

			
			if ( !( this.detectTime != 0 ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
				aiPlayer = _a;
				

				if ( this.status ) {
					aiPlayer.triggerAlarm( "Motion", GlobalFuncs.get_area( this ), new ByTable(new object [] { this }), this );
				}
			}
			this.detectTime = -1;
			return true;
		}

		// Function from file: motion.dm
		public bool cancelAlarm(  ) {
			Mob_Living_Silicon aiPlayer = null;

			
			if ( this.detectTime == -1 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
					aiPlayer = _a;
					

					if ( this.status ) {
						aiPlayer.cancelAlarm( "Motion", GlobalFuncs.get_area( this ), this );
					}
				}
			}
			this.detectTime = 0;
			return true;
		}

		// Function from file: motion.dm
		public void lostTarget( dynamic target = null ) {
			
			if ( this.motionTargets.Contains( target ) ) {
				this.motionTargets.Remove( target );
			}

			if ( this.motionTargets.len == 0 ) {
				this.cancelAlarm();
			}
			return;
		}

		// Function from file: motion.dm
		public bool newTarget( dynamic target = null ) {
			
			if ( target is Mob_Living_Silicon_Ai ) {
				return false;
			}

			if ( this.detectTime == 0 ) {
				this.detectTime = Game13.time;
			}

			if ( !this.motionTargets.Contains( target ) ) {
				this.motionTargets.Add( target );
			}
			return true;
		}

		// Function from file: camera.dm
		public void Togglelight( bool? on = null ) {
			on = on ?? false;

			Mob_Living_Silicon_Ai A = null;
			Obj_Machinery_Camera cam = null;

			
			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.ai_list, typeof(Mob_Living_Silicon_Ai) )) {
				A = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( A.lit_cameras, typeof(Obj_Machinery_Camera) )) {
					cam = _a;
					

					if ( cam == this ) {
						return;
					}
				}
			}

			if ( on == true ) {
				this.SetLuminosity( 5 );
			} else {
				this.SetLuminosity( 0 );
			}
			return;
		}

		// Function from file: camera.dm
		public bool weld( dynamic WT = null, dynamic user = null ) {
			
			if ( this.busy ) {
				return false;
			}

			if ( !((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
				return false;
			}
			user.WriteMsg( "<span class='notice'>You start to weld " + this + "...</span>" );
			GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
			this.busy = true;

			if ( GlobalFuncs.do_after( user, 100, null, this ) ) {
				this.busy = false;

				if ( !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
					return false;
				}
				return true;
			}
			this.busy = false;
			return false;
		}

		// Function from file: camera.dm
		public ByTable can_see(  ) {
			ByTable see = null;
			dynamic pos = null;

			see = null;
			pos = GlobalFuncs.get_turf( this );

			if ( this.isXRay() != 0 ) {
				see = Map13.FetchInRange( pos, this.view_range );
			} else {
				see = GlobalFuncs.get_hear( this.view_range, pos );
			}
			return see;
		}

		// Function from file: camera.dm
		public bool can_use(  ) {
			
			if ( !this.status ) {
				return false;
			}

			if ( ( this.stat & 16 ) != 0 ) {
				return false;
			}
			return true;
		}

		// Function from file: camera.dm
		public void cancelCameraAlarm(  ) {
			Mob_Living_Silicon S = null;

			this.alarm_on = false;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Silicon) )) {
				S = _a;
				
				S.cancelAlarm( "Camera", GlobalFuncs.get_area( this ), this );
			}
			return;
		}

		// Function from file: camera.dm
		public void triggerCameraAlarm(  ) {
			Mob_Living_Silicon S = null;

			this.alarm_on = true;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Silicon) )) {
				S = _a;
				
				S.triggerAlarm( "Camera", GlobalFuncs.get_area( this ), new ByTable(new object [] { this }), this );
			}
			return;
		}

		// Function from file: camera.dm
		public void toggle_cam( dynamic user = null, bool? displaymessage = null ) {
			displaymessage = displaymessage ?? true;

			string change_msg = null;
			dynamic O = null;

			this.status = !this.status;

			if ( this.can_use() ) {
				GlobalVars.cameranet.addCamera( this );
			} else {
				this.SetLuminosity( 0 );
				GlobalVars.cameranet.removeCamera( this );
			}
			GlobalVars.cameranet.updateChunk( this.x, this.y, this.z );
			change_msg = "deactivates";

			if ( !this.status ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "1";
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
				change_msg = "reactivates";
				this.triggerCameraAlarm();
				Task13.Schedule( 100, (Task13.Closure)(() => {
					
					if ( !Lang13.Bool( GlobalFuncs.qdeleted( this ) ) ) {
						this.cancelCameraAlarm();
					}
					return;
				}));
			}

			if ( displaymessage == true ) {
				
				if ( Lang13.Bool( user ) ) {
					this.visible_message( "<span class='danger'>" + user + " " + change_msg + " " + this + "!</span>" );
					this.add_hiddenprint( user );
				} else {
					this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " " ).item( change_msg ).str( "!</span>" ).ToString() );
				}
				GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				O = _a;
				

				if ( Lang13.Bool( O.client ) && O.client.eye == this ) {
					((Mob)O).unset_machine();
					((Mob)O).reset_perspective( null );
					O.WriteMsg( "The screen bursts into static." );
				}
			}
			return;
		}

		// Function from file: camera.dm
		public void shock( Mob_Living user = null ) {
			
			if ( !( user is Mob_Living ) ) {
				return;
			}
			user.electrocute_act( 10, this );
			return;
		}

		// Function from file: camera.dm
		public void setViewRange( dynamic num = null ) {
			num = num ?? 7;

			this.view_range = num;
			GlobalVars.cameranet.updateVisibility( this, false );
			return;
		}

		// Function from file: camera.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.invuln ) ) {
				return false;
			} else {
				base.ex_act( severity, (object)(target) );
			}
			return false;
		}

		// Function from file: camera.dm
		public override double emp_act( int severity = 0 ) {
			ByTable previous_network = null;
			int thisemp = 0;
			dynamic O = null;

			
			if ( !this.status ) {
				return 0;
			}

			if ( !( this.isEmpProof() != 0 ) ) {
				
				if ( Rand13.PercentChance( ((int)( 150 / severity )) ) ) {
					this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "emp";
					previous_network = this.network;
					this.network = new ByTable();
					GlobalVars.cameranet.removeCamera( this );
					this.stat |= 16;
					this.SetLuminosity( 0 );
					this.emped = this.emped + 1;
					thisemp = this.emped;
					Task13.Schedule( 900, (Task13.Closure)(() => {
						
						if ( this.loc != null ) {
							this.triggerCameraAlarm();

							if ( this.emped == thisemp ) {
								this.network = previous_network;
								this.icon_state = Lang13.Initial( this, "icon_state" );
								this.stat &= 65519;

								if ( this.can_use() ) {
									GlobalVars.cameranet.addCamera( this );
								}
								this.emped = 0;
								Task13.Schedule( 100, (Task13.Closure)(() => {
									
									if ( !Lang13.Bool( GlobalFuncs.qdeleted( this ) ) ) {
										this.cancelCameraAlarm();
									}
									return;
								}));
							}
						}
						return;
					}));

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list )) {
						O = _a;
						

						if ( Lang13.Bool( O.client ) && O.client.eye == this ) {
							((Mob)O).unset_machine();
							((Mob)O).reset_perspective( null );
							O.WriteMsg( "The screen bursts into static." );
						}
					}
					base.emp_act( severity );
				}
			}
			return 0;
		}

		// Function from file: camera.dm
		public override void initialize(  ) {
			
			if ( this.z == 1 && Rand13.PercentChance( 3 ) && !this.start_active ) {
				this.toggle_cam();
			}
			return;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.DisIntegrate( this );
			this.toggle_cam( S, false );
			return;
		}

	}

}