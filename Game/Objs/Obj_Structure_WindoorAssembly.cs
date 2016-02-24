// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_WindoorAssembly : Obj_Structure {

		public dynamic ini_dir = null;
		public dynamic electronics = null;
		public string created_name = null;
		public string facing = "l";
		public bool secure = false;
		public string state = "01";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/doors/windoor.dmi";
			this.icon_state = "l_windoor_assembly01";
			this.dir = 1;
		}

		// Function from file: windoor_assembly.dm
		public Obj_Structure_WindoorAssembly ( dynamic dir = null ) : base( (object)(dir) ) {
			dir = dir ?? GlobalVars.NORTH;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.ini_dir = dir;
			this.air_update_turf( true );
			return;
		}

		// Function from file: windoor_assembly.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( user.incapacitated() ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.__CallVerb("Rotate Windoor Assembly" );
			}
			return false;
		}

		// Function from file: windoor_assembly.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;
			Obj_Item_Stack_Sheet_Rglass RG = null;
			Obj_Item_Stack_Rods R = null;
			Obj_Machinery_Door_Window WD = null;
			Obj_Machinery_Door_Window WD2 = null;
			dynamic P = null;
			dynamic CC = null;
			dynamic ae = null;
			string t = null;
			Obj_Machinery_Door_Window_Brigdoor windoor = null;
			Obj_Machinery_Door_Window windoor2 = null;

			this.add_fingerprint( user );

			switch ((string)( this.state )) {
				case "01":
					
					if ( A is Obj_Item_Weapon_Weldingtool && !Lang13.Bool( this.anchored ) ) {
						WT = A;

						if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
							((Ent_Static)user).visible_message( "" + user + " disassembles the windoor assembly.", "<span class='notice'>You start to disassemble the windoor assembly...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
								
								if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
									return null;
								}
								user.WriteMsg( "<span class='notice'>You disassemble the windoor assembly.</span>" );
								RG = new Obj_Item_Stack_Sheet_Rglass( GlobalFuncs.get_turf( this ), 5 );
								RG.add_fingerprint( user );

								if ( this.secure ) {
									R = new Obj_Item_Stack_Rods( GlobalFuncs.get_turf( this ), 4 );
									R.add_fingerprint( user );
								}
								GlobalFuncs.qdel( this );
							}
						} else {
							return null;
						}
					}

					if ( A is Obj_Item_Weapon_Wrench && !Lang13.Bool( this.anchored ) ) {
						
						foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Machinery_Door_Window) )) {
							WD = _a;
							

							if ( WD.dir == this.dir ) {
								user.WriteMsg( "<span class='warning'>There is already a windoor in that location!</span>" );
								return null;
							}
						}
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " secures the windoor assembly to the floor.", "<span class='notice'>You start to secure the windoor assembly to the floor...</span>" );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || Lang13.Bool( this.anchored ) ) {
								return null;
							}

							foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Machinery_Door_Window) )) {
								WD2 = _b;
								

								if ( WD2.dir == this.dir ) {
									user.WriteMsg( "<span class='warning'>There is already a windoor in that location!</span>" );
									return null;
								}
							}
							user.WriteMsg( "<span class='notice'>You secure the windoor assembly.</span>" );
							this.anchored = 1;

							if ( this.secure ) {
								this.name = "secure anchored windoor assembly";
							} else {
								this.name = "anchored windoor assembly";
							}
						}
					} else if ( A is Obj_Item_Weapon_Wrench && Lang13.Bool( this.anchored ) ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " unsecures the windoor assembly to the floor.", "<span class='notice'>You start to unsecure the windoor assembly to the floor...</span>" );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !Lang13.Bool( this.anchored ) ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>You unsecure the windoor assembly.</span>" );
							this.anchored = 0;

							if ( this.secure ) {
								this.name = "secure windoor assembly";
							} else {
								this.name = "windoor assembly";
							}
						}
					} else if ( A is Obj_Item_Stack_Sheet_Plasteel && !this.secure ) {
						P = A;

						if ( Convert.ToDouble( P.amount ) < 2 ) {
							user.WriteMsg( "<span class='warning'>You need more plasteel to do this!</span>" );
							return null;
						}
						user.WriteMsg( "<span class='notice'>You start to reinforce the windoor with plasteel...</span>" );

						if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
							
							if ( !( this != null ) || this.secure ) {
								return null;
							}
							P.use( 2 );
							user.WriteMsg( "<span class='notice'>You reinforce the windoor.</span>" );
							this.secure = true;

							if ( Lang13.Bool( this.anchored ) ) {
								this.name = "secure anchored windoor assembly";
							} else {
								this.name = "secure windoor assembly";
							}
						}
					} else if ( A is Obj_Item_Stack_CableCoil && Lang13.Bool( this.anchored ) ) {
						((Ent_Static)user).visible_message( "" + user + " wires the windoor assembly.", "<span class='notice'>You start to wire the windoor assembly...</span>" );

						if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
							
							if ( !( this != null ) || !Lang13.Bool( this.anchored ) || this.state != "01" ) {
								return null;
							}
							CC = A;

							if ( !Lang13.Bool( CC.use( 1 ) ) ) {
								user.WriteMsg( "<span class='warning'>You need more cable to do this!</span>" );
								return null;
							}
							user.WriteMsg( "<span class='notice'>You wire the windoor.</span>" );
							this.state = "02";

							if ( this.secure ) {
								this.name = "secure wired windoor assembly";
							} else {
								this.name = "wired windoor assembly";
							}
						}
					} else {
						base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
					}
					break;
				case "02":
					
					if ( A is Obj_Item_Weapon_Wirecutters ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " cuts the wires from the airlock assembly.", "<span class='notice'>You start to cut the wires from airlock assembly...</span>" );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || this.state != "02" ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>You cut the windoor wires.</span>" );
							new Obj_Item_Stack_CableCoil( GlobalFuncs.get_turf( user ), 1 );
							this.state = "01";

							if ( this.secure ) {
								this.name = "secure anchored windoor assembly";
							} else {
								this.name = "anchored windoor assembly";
							}
						}
					} else if ( A is Obj_Item_Weapon_Electronics_Airlock ) {
						
						if ( !Lang13.Bool( user.drop_item() ) ) {
							return null;
						}
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " installs the electronics into the airlock assembly.", "<span class='notice'>You start to install electronics into the airlock assembly...</span>" );
						A.loc = this;

						if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
							
							if ( !( this != null ) || Lang13.Bool( this.electronics ) ) {
								A.loc = this.loc;
								return null;
							}
							user.WriteMsg( "<span class='notice'>You install the airlock electronics.</span>" );
							this.name = "near finished windoor assembly";
							this.electronics = A;
						} else {
							A.loc = this.loc;
						}
					} else if ( A is Obj_Item_Weapon_Screwdriver ) {
						
						if ( !Lang13.Bool( this.electronics ) ) {
							return null;
						}
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " removes the electronics from the airlock assembly.", "<span class='notice'>You start to uninstall electronics from the airlock assembly...</span>" );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !Lang13.Bool( this.electronics ) ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>You remove the airlock electronics.</span>" );
							this.name = "wired windoor assembly";
							ae = null;
							ae = this.electronics;
							this.electronics = null;
							ae.loc = this.loc;
						}
					} else if ( A is Obj_Item_Weapon_Pen ) {
						t = GlobalFuncs.stripped_input( user, "Enter the name for the door.", this.name, this.created_name, 26 );

						if ( !Lang13.Bool( t ) ) {
							return null;
						}

						if ( !( Map13.GetDistance( this, Task13.User ) <= 1 ) && this.loc != Task13.User ) {
							return null;
						}
						this.created_name = t;
						return null;
					} else if ( A is Obj_Item_Weapon_Crowbar ) {
						
						if ( !Lang13.Bool( this.electronics ) ) {
							Task13.User.WriteMsg( "<span class='warning'>The assembly is missing electronics!</span>" );
							return null;
						}
						Interface13.Browse( Task13.User, null, "window=windoor_access" );
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );
						((Ent_Static)user).visible_message( "" + user + " pries the windoor into the frame.", "<span class='notice'>You start prying the windoor into the frame...</span>" );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( this.loc != null && Lang13.Bool( this.electronics ) ) {
								this.density = true;
								user.WriteMsg( "<span class='notice'>You finish the windoor.</span>" );

								if ( this.secure ) {
									windoor = new Obj_Machinery_Door_Window_Brigdoor( this.loc );

									if ( this.facing == "l" ) {
										windoor.icon_state = "leftsecureopen";
										windoor.base_state = "leftsecure";
									} else {
										windoor.icon_state = "rightsecureopen";
										windoor.base_state = "rightsecure";
									}
									windoor.dir = this.dir;
									windoor.density = false;

									if ( this.electronics.one_access ) {
										windoor.req_one_access = this.electronics.accesses;
									} else {
										windoor.req_access = this.electronics.accesses;
									}
									windoor.electronics = this.electronics;
									this.electronics.loc = windoor;

									if ( Lang13.Bool( this.created_name ) ) {
										windoor.name = this.created_name;
									}
									GlobalFuncs.qdel( this );
									windoor.close();
								} else {
									windoor2 = new Obj_Machinery_Door_Window( this.loc );

									if ( this.facing == "l" ) {
										windoor2.icon_state = "leftopen";
										windoor2.base_state = "left";
									} else {
										windoor2.icon_state = "rightopen";
										windoor2.base_state = "right";
									}
									windoor2.dir = this.dir;
									windoor2.density = false;
									windoor2.req_access = this.electronics.accesses;
									windoor2.electronics = this.electronics;
									this.electronics.loc = windoor2;

									if ( Lang13.Bool( this.created_name ) ) {
										windoor2.name = this.created_name;
									}
									GlobalFuncs.qdel( this );
									windoor2.close();
								}
							}
						}
					} else {
						base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
					}
					break;
			}
			this.update_icon();
			return null;
		}

		// Function from file: windoor_assembly.dm
		public override bool CheckExit( Ent_Dynamic mover = null, Tile target = null ) {
			
			if ( mover is Ent_Dynamic && mover.checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: windoor_assembly.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			
			if ( Map13.GetDistance( this.loc, T ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: windoor_assembly.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: windoor_assembly.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "" + this.facing + "_" + ( this.secure ? "secure_" : "" ) + "windoor_assembly" + this.state;
			return false;
		}

		// Function from file: windoor_assembly.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static T = null;

			T = this.loc;
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.move_update_air( T );
			return false;
		}

		// Function from file: windoor_assembly.dm
		public override dynamic Destroy(  ) {
			this.density = false;
			this.air_update_turf( true );
			return base.Destroy();
		}

		// Function from file: windoor_assembly.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='notice'>Alt-click to rotate it clockwise.</span>" );
			return 0;
		}

		// Function from file: windoor_assembly.dm
		[Verb]
		[VerbInfo( name: "Flip Windoor Assembly", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void flip(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}

			if ( this.facing == "l" ) {
				Task13.User.WriteMsg( "<span class='notice'>The windoor will now slide to the right.</span>" );
				this.facing = "r";
			} else {
				this.facing = "l";
				Task13.User.WriteMsg( "<span class='notice'>The windoor will now slide to the left.</span>" );
			}
			this.update_icon();
			return;
		}

		// Function from file: windoor_assembly.dm
		[Verb]
		[VerbInfo( name: "Rotate Windoor Assembly", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool revrotate(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return false;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				Task13.User.WriteMsg( "<span class='warning'>It is fastened to the floor; therefore, you can't rotate it!</span>" );
				return false;
			}
			this.dir = Num13.Rotate( this.dir, 270 );
			this.ini_dir = this.dir;
			this.update_icon();
			return false;
		}

	}

}