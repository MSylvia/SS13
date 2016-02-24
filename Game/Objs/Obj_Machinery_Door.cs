// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door : Obj_Machinery {

		public int secondsElectrified = 0;
		public bool visible = true;
		public bool p_open = false;
		public bool operating = false;
		public bool glass = false;
		public bool normalspeed = true;
		public bool heat_proof = false;
		public bool? emergency = false;
		public bool sub_door = false;
		public double closingLayer = 301;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.power_channel = 3;
			this.icon = "icons/obj/doors/Doorint.dmi";
			this.icon_state = "door1";
			this.layer = 2.7;
		}

		// Function from file: door.dm
		public Obj_Machinery_Door ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.density ) {
				this.layer = 301;
			} else {
				this.layer = 2.7;
			}
			this.update_freelook_sight();
			this.air_update_turf( true );
			GlobalVars.airlocks.Add( this );
			return;
		}

		// Function from file: shuttle.dm
		public override bool onShuttleMove( Ent_Static T1 = null, double? rotation = null ) {
			bool _default = false;

			_default = base.onShuttleMove( T1, rotation );

			if ( !_default ) {
				return _default;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.close();
				return;
			}));
			return _default;
		}

		// Function from file: door.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			return false;
		}

		// Function from file: door.dm
		public override bool BlockSuperconductivity(  ) {
			
			if ( this.opacity || this.heat_proof ) {
				return true;
			}
			return false;
		}

		// Function from file: door.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.density ) {
				this.icon_state = "door1";
			} else {
				this.icon_state = "door0";
			}
			return false;
		}

		// Function from file: door.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			EffectSystem_SparkSpread s = null;

			
			if ( severity == 3 ) {
				
				if ( Rand13.PercentChance( 80 ) ) {
					s = new EffectSystem_SparkSpread();
					s.set_up( 2, 1, this );
					s.start();
				}
				return false;
			}
			base.ex_act( severity, (object)(target) );
			return false;
		}

		// Function from file: door.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( Rand13.PercentChance( ((int)( 20 / severity )) ) && ( this is Obj_Machinery_Door_Airlock || this is Obj_Machinery_Door_Window ) ) {
				this.open();
			}

			if ( Rand13.PercentChance( ((int)( 40 / severity )) ) ) {
				
				if ( this.secondsElectrified == 0 ) {
					this.secondsElectrified = -1;
					Task13.Schedule( 300, (Task13.Closure)(() => {
						this.secondsElectrified = 0;
						return;
					}));
				}
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: door.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 40 ) ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: door.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Device_DetectiveScanner ) {
				return null;
			}

			if ( user is Mob_Living_Silicon_Robot ) {
				return null;
			}
			this.add_fingerprint( user );

			if ( this.operating || Lang13.Bool( this.emagged ) ) {
				return null;
			}

			if ( !this.Adjacent( user ) ) {
				user = null;
			}

			if ( !this.requiresID() ) {
				user = null;
			}

			if ( this.allowed( user ) || this.emergency == true ) {
				
				if ( this.density ) {
					this.open();
				} else {
					this.close();
				}
				return null;
			}

			if ( this.density ) {
				this.do_animate( "deny" );
			}
			return null;
		}

		// Function from file: door.dm
		public override void attack_tk( Mob_Living_Carbon_Human user = null ) {
			
			if ( this.requiresID() && !this.allowed( null ) ) {
				return;
			}
			base.attack_tk( user );
			return;
		}

		// Function from file: door.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			return this.attackby( a, a );
		}

		// Function from file: door.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: door.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: door.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			return !this.density;
		}

		// Function from file: door.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 2 ) != 0 ) {
				return !this.opacity;
			}
			return !this.density;
		}

		// Function from file: door.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static T = null;

			T = this.loc;
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.move_update_air( T );
			return false;
		}

		// Function from file: door.dm
		public override bool Bumped( dynamic AM = null ) {
			dynamic M = null;
			dynamic mecha = null;

			
			if ( this.operating || Lang13.Bool( this.emagged ) ) {
				return false;
			}

			if ( AM is Mob_Living ) {
				M = AM;

				if ( Game13.time - M.last_bumped <= 10 ) {
					return false;
				}
				M.last_bumped = Game13.time;

				if ( !((Mob)M).restrained() ) {
					this.bumpopen( M );
				}
				return false;
			}

			if ( AM is Obj_Mecha ) {
				mecha = AM;

				if ( this.density ) {
					
					if ( Lang13.Bool( mecha.occupant ) && ( this.allowed( mecha.occupant ) || this.check_access_list( mecha.operation_req_access ) || this.emergency == true ) ) {
						this.open();
					} else {
						this.do_animate( "deny" );
					}
				}
				return false;
			}
			return false;
		}

		// Function from file: door.dm
		public override dynamic Destroy(  ) {
			this.density = false;
			this.air_update_turf( true );
			this.update_freelook_sight();
			GlobalVars.airlocks.Remove( this );
			return base.Destroy();
		}

		// Function from file: door.dm
		public void update_freelook_sight(  ) {
			
			if ( !this.glass && GlobalVars.cameranet != null ) {
				GlobalVars.cameranet.updateVisibility( this, false );
			}
			return;
		}

		// Function from file: door.dm
		public virtual bool hasPower(  ) {
			return !( ( this.stat & 2 ) != 0 );
		}

		// Function from file: door.dm
		public virtual bool requiresID(  ) {
			return true;
		}

		// Function from file: door.dm
		public void crush(  ) {
			Mob_Living L = null;
			Ent_Static location = null;
			Obj_Mecha M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Mob_Living) )) {
				L = _a;
				

				if ( L is Mob_Living_Carbon_Alien ) {
					L.adjustBruteLoss( 22.5 );
					L.emote( "roar" );
				} else if ( L is Mob_Living_Carbon_Human ) {
					L.adjustBruteLoss( 15 );
					L.emote( "scream" );
					L.Weaken( 5 );
				} else if ( L is Mob_Living_Carbon_Monkey ) {
					L.adjustBruteLoss( 15 );
					L.Weaken( 5 );
				} else {
					L.adjustBruteLoss( 15 );
				}
				location = this.loc;

				if ( location is Tile_Simulated ) {
					location.add_blood_floor( L );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Obj_Mecha) )) {
				M = _b;
				
				M.take_damage( 15 );
			}
			return;
		}

		// Function from file: door.dm
		public virtual bool close( int? surpress_send = null ) {
			
			if ( this.density ) {
				return true;
			}

			if ( this.operating ) {
				return false;
			}
			this.operating = true;
			this.do_animate( "closing" );
			this.layer = this.closingLayer;
			Task13.Sleep( 5 );
			this.density = true;
			Task13.Sleep( 5 );
			this.update_icon();

			if ( this.visible && !this.glass ) {
				this.SetOpacity( 1 );
			}
			this.CheckForMobs();
			this.operating = false;
			this.air_update_turf( true );
			this.update_freelook_sight();
			return false;
		}

		// Function from file: door.dm
		public virtual bool open( int? surpress_send = null ) {
			
			if ( !this.density ) {
				return true;
			}

			if ( this.operating ) {
				return false;
			}

			if ( !( GlobalVars.ticker != null ) || !Lang13.Bool( GlobalVars.ticker.mode ) ) {
				return false;
			}
			this.operating = true;
			this.do_animate( "opening" );
			this.icon_state = "door0";
			this.SetOpacity( 0 );
			Task13.Sleep( 5 );
			this.density = false;
			Task13.Sleep( 5 );
			this.layer = 2.7;
			this.update_icon();
			this.SetOpacity( 0 );
			this.operating = false;
			this.air_update_turf( true );
			this.update_freelook_sight();
			return true;
		}

		// Function from file: door.dm
		public virtual void do_animate( string animation = null ) {
			
			switch ((string)( animation )) {
				case "opening":
					
					if ( this.p_open ) {
						Icon13.Flick( "o_doorc0", this );
					} else {
						Icon13.Flick( "doorc0", this );
					}
					break;
				case "closing":
					
					if ( this.p_open ) {
						Icon13.Flick( "o_doorc1", this );
					} else {
						Icon13.Flick( "doorc1", this );
					}
					break;
				case "deny":
					Icon13.Flick( "door_deny", this );
					break;
			}
			return;
		}

		// Function from file: door.dm
		public virtual void bumpopen( dynamic user = null ) {
			
			if ( this.operating ) {
				return;
			}
			this.add_fingerprint( user );

			if ( !this.requiresID() ) {
				user = null;
			}

			if ( this.density && !Lang13.Bool( this.emagged ) ) {
				
				if ( this.allowed( user ) || this.emergency == true ) {
					this.open();
				} else {
					this.do_animate( "deny" );
				}
			}
			return;
		}

		// Function from file: door.dm
		public void CheckForMobs(  ) {
			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Mob_Living), GlobalFuncs.get_turf( this ) ) ) ) {
				Task13.Sleep( 1 );
				this.open();
			}
			return;
		}

		// Function from file: checkForMultipleDoors.dm
		public bool checkForMultipleDoors(  ) {
			Obj_Machinery_Door D = null;

			
			if ( !( this.loc != null ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Machinery_Door) )) {
				D = _a;
				

				if ( !( D is Obj_Machinery_Door_Window ) && D.density && D != this ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.DisIntegrate( this );
			return;
		}

	}

}