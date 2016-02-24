// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_TransitTube_Station : Obj_Structure_TransitTube {

		public bool pod_moving = false;
		public int cooldown_delay = 50;
		public int launch_cooldown = 0;
		public bool? reverse_launch = false;
		public int OPEN_DURATION = 6;
		public int CLOSE_DURATION = 6;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.enter_delay = 2;
			this.tube_construction = typeof(Obj_Structure_CTransitTube_Station);
			this.icon = "icons/obj/atmospherics/pipes/transit_tube_station.dmi";
			this.icon_state = "closed";
		}

		// Function from file: station.dm
		public Obj_Structure_TransitTube_Station ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSobj.processing.Add( this );
			return;
		}

		// Function from file: station.dm
		public override void init_dirs(  ) {
			this.tube_dirs = new ByTable(new object [] { Num13.Rotate( this.dir, 90 ), Num13.Rotate( this.dir, -90 ) });
			return;
		}

		// Function from file: station.dm
		public override void pod_stopped( Obj_Structure_TransitTubePod pod = null, int from_dir = 0 ) {
			this.pod_moving = true;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.launch_cooldown = Game13.time + this.cooldown_delay;
				this.open_animation();
				Task13.Sleep( 8 );
				this.pod_moving = false;
				pod.mix_air();
				return;
			}));
			return;
		}

		// Function from file: station.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( !this.pod_moving ) {
				this.launch_pod();
			}
			return null;
		}

		// Function from file: station.dm
		public bool launch_pod(  ) {
			Obj_Structure_TransitTubePod pod = null;

			
			if ( this.launch_cooldown >= Game13.time ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
				pod = _a;
				

				if ( this.directions().Contains( !pod.moving && Num13.Rotate( pod.dir, ( this.reverse_launch == true ? 180 : 0 ) ) != 0 ) ) {
					this.pod_moving = true;
					this.close_animation();
					Task13.Sleep( 8 );

					if ( this.icon_state == "closed" && pod != null ) {
						pod.follow_tube( this.reverse_launch );
					}
					this.pod_moving = false;
					return true;
				}
			}
			return false;
		}

		// Function from file: station.dm
		public void close_animation(  ) {
			
			if ( this.icon_state == "open" ) {
				this.icon_state = "closing";
				Task13.Schedule( GlobalVars.CLOSE_DURATION, (Task13.Closure)(() => {
					
					if ( this.icon_state == "closing" ) {
						this.icon_state = "closed";
					}
					return;
				}));
			}
			return;
		}

		// Function from file: station.dm
		public void open_animation(  ) {
			
			if ( this.icon_state == "closed" ) {
				this.icon_state = "opening";
				Task13.Schedule( GlobalVars.OPEN_DURATION, (Task13.Closure)(() => {
					
					if ( this.icon_state == "opening" ) {
						this.icon_state = "open";
					}
					return;
				}));
			}
			return;
		}

		// Function from file: station.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic G = null;
			Mob GM = null;
			Obj_Structure_TransitTubePod pod = null;
			Obj_Structure_TransitTubePod pod2 = null;
			Obj_Structure_CTransitTubePod R = null;

			
			if ( A is Obj_Item_Weapon_Grab && this.icon_state == "open" ) {
				G = A;

				if ( G.affecting is Mob && Convert.ToDouble( G.state ) >= 2 ) {
					GM = G.affecting;

					foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
						pod = _a;
						
						pod.visible_message( "<span class='warning'>" + user + " starts putting " + GM + " into the " + pod + "!</span>" );

						if ( GlobalFuncs.do_after( user, 15, null, this ) && GM != null && Lang13.Bool( G ) && G.affecting == GM ) {
							GM.Weaken( 5 );
							this.Bumped( GM );
							GlobalFuncs.qdel( G );
						}
						break;
					}
				}
			}

			if ( A is Obj_Item_Weapon_Crowbar ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
					pod2 = _b;
					

					if ( pod2.contents != null ) {
						user.WriteMsg( "<span class='warning'>Empty the pod first!</span>" );
						return null;
					}
					((Ent_Static)user).visible_message( "" + user + " removes the " + pod2 + ".", "<span class='notice'>You remove the " + pod2 + ".</span>" );
					R = new Obj_Structure_CTransitTubePod( this.loc );
					pod2.transfer_fingerprints_to( R );
					R.add_fingerprint( user );
					GlobalFuncs.qdel( pod2 );
				}
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: station.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			Obj_Structure_TransitTubePod pod = null;
			Ent_Dynamic AM = null;
			Ent_Dynamic M = null;

			
			if ( !this.pod_moving ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
					pod = _b;
					

					if ( this.directions().Contains( !pod.moving && pod.dir != 0 ) ) {
						
						if ( this.icon_state == "closed" ) {
							this.open_animation();
						} else if ( this.icon_state == "open" ) {
							
							if ( pod.contents.len != 0 && a.loc != pod ) {
								((Ent_Static)a).visible_message( "" + a + " starts emptying " + pod + "'s contents onto the floor.", "<span class='notice'>You start emptying " + pod + "'s contents onto the floor...</span>" );

								if ( GlobalFuncs.do_after( a, 10, null, this ) ) {
									
									if ( pod.loc == this.loc ) {
										
										foreach (dynamic _a in Lang13.Enumerate( pod, typeof(Ent_Dynamic) )) {
											AM = _a;
											
											AM.loc = GlobalFuncs.get_turf( a );

											if ( AM is Mob ) {
												M = AM;
												((dynamic)M).Weaken( 5 );
											}
										}
									}
								}
							} else {
								this.close_animation();
							}
						}
					}
					break;
				}
			}
			return null;
		}

		// Function from file: station.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			Obj_Structure_TransitTubePod pod = null;
			Obj_Structure_TransitTubePod T = null;

			
			if ( !user.canmove || user.stat != 0 || user.restrained() ) {
				return false;
			}

			if ( !( dropping is Obj_Structure_CTransitTubePod ) || Map13.GetDistance( user, this ) > 1 || Map13.GetDistance( this, dropping ) > 1 ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
				pod = _a;
				
				return false;
			}
			T = new Obj_Structure_TransitTubePod( this );
			dropping.transfer_fingerprints_to( T );
			T.add_fingerprint( user );
			T.loc = this.loc;
			T.dir = Num13.Rotate( this.dir, -90 );
			user.visible_message( "" + user + " inserts the " + dropping + ".", "<span class='notice'>You insert the " + dropping + ".</span>" );
			GlobalFuncs.qdel( dropping );
			return false;
		}

		// Function from file: station.dm
		public override bool Bumped( dynamic AM = null ) {
			Obj_Structure_TransitTubePod pod = null;

			
			if ( !this.pod_moving && this.icon_state == "open" && AM is Mob ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_TransitTubePod) )) {
					pod = _a;
					

					if ( this.directions().Contains( !pod.moving && pod.dir != 0 ) ) {
						AM.loc = pod;
						return false;
					}
				}
			}
			return false;
		}

		// Function from file: station.dm
		public override bool should_stop_pod( Obj_Structure_TransitTubePod pod = null, dynamic from_dir = null ) {
			return true;
		}

		// Function from file: station.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return base.Destroy();
		}

	}

}