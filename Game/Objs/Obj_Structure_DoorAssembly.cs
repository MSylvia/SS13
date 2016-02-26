// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly : Obj_Structure {

		public AirlockMaker maker = null;
		public string overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
		public int state = 0;
		public string mineral = null;
		public string typetext = "";
		public string icontext = "";
		public dynamic electronics = null;
		public Type airlock_type = typeof(Obj_Machinery_Door_Airlock);
		public Type glass_type = typeof(Obj_Machinery_Door_Airlock_Glass);
		public string created_name = null;
		public bool heat_proof_finished = false;
		public string material = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/doors/airlocks/station/public.dmi";
			this.icon_state = "construction";
		}

		// Function from file: door_assembly.dm
		public Obj_Structure_DoorAssembly ( dynamic loc = null ) : base( (object)(loc) ) {
			this.update_icon();
			return;
		}

		// Function from file: door_assembly.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( !Lang13.Bool( this.material ) ) {
				this.overlays.Add( GlobalFuncs.get_airlock_overlay( "fill_construction", this.icon ) );
			} else {
				this.overlays.Add( GlobalFuncs.get_airlock_overlay( "" + this.material + "_construction", this.overlays_file ) );
			}
			this.overlays.Add( GlobalFuncs.get_airlock_overlay( "panel_c" + ( this.state + 1 ), this.overlays_file ) );
			return false;
		}

		// Function from file: door_assembly.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			string t = null;
			dynamic WT = null;
			dynamic icontype = null;
			ByTable optionlist = null;
			bool has_solid = false;
			bool has_glass = false;
			dynamic WT2 = null;
			Type M = null;
			bool door_check = false;
			Obj_Machinery_Door D = null;
			dynamic C = null;
			dynamic ae = null;
			dynamic G = null;
			string M2 = null;
			dynamic door = null;

			
			if ( A is Obj_Item_Weapon_Pen ) {
				t = GlobalFuncs.stripped_input( user, "Enter the name for the door.", this.name, this.created_name, 26 );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}

				if ( !( Map13.GetDistance( this, Task13.User ) <= 1 ) && this.loc != Task13.User ) {
					return null;
				}
				this.created_name = t;
				return null;
			} else if ( A is Obj_Item_Weapon_AirlockPainter ) {
				WT = A;

				if ( Lang13.Bool( WT.can_use( user ) ) ) {
					
					if ( Lang13.Bool( this.mineral ) && this.mineral == "glass" ) {
						optionlist = new ByTable(new object [] { "Public", "Public2", "Engineering", "Atmospherics", "Security", "Command", "Medical", "Research", "Science", "Mining" });
					} else {
						optionlist = new ByTable(new object [] { "Public", "Engineering", "Atmospherics", "Security", "Command", "Medical", "Research", "Science", "Mining", "Maintenance", "External", "High Security" });
					}
					icontype = Interface13.Input( user, "Please select a paintjob for this airlock.", null, null, optionlist, InputType.Any );

					if ( !( Map13.GetDistance( this, Task13.User ) <= 1 ) && this.loc != Task13.User || !Lang13.Bool( WT.use( user ) ) ) {
						return null;
					}
					has_solid = false;
					has_glass = false;

					dynamic _a = icontype; // Was a switch-case, sorry for the mess.
					if ( _a=="Public" ) {
						this.icon = "icons/obj/doors/airlocks/station/public.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "";
						this.icontext = "";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Public2" ) {
						this.icon = "icons/obj/doors/airlocks/station2/glass.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station2/overlays.dmi";
						this.typetext = "";
						this.icontext = "";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Engineering" ) {
						this.icon = "icons/obj/doors/airlocks/station/engineering.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "engineering";
						this.icontext = "eng";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Atmospherics" ) {
						this.icon = "icons/obj/doors/airlocks/station/atmos.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "atmos";
						this.icontext = "atmo";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Security" ) {
						this.icon = "icons/obj/doors/airlocks/station/security.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "security";
						this.icontext = "sec";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Command" ) {
						this.icon = "icons/obj/doors/airlocks/station/command.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "command";
						this.icontext = "com";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Medical" ) {
						this.icon = "icons/obj/doors/airlocks/station/medical.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "medical";
						this.icontext = "med";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Research" ) {
						this.icon = "icons/obj/doors/airlocks/station/research.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "research";
						this.icontext = "res";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Science" ) {
						this.icon = "icons/obj/doors/airlocks/station/science.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "research";
						this.icontext = "res";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Mining" ) {
						this.icon = "icons/obj/doors/airlocks/station/mining.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "mining";
						this.icontext = "min";
						has_solid = true;
						has_glass = true;
					} else if ( _a=="Maintenance" ) {
						this.icon = "icons/obj/doors/airlocks/station/maintenance.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/station/overlays.dmi";
						this.typetext = "maintenance";
						this.icontext = "mai";
						has_solid = true;
						has_glass = false;
					} else if ( _a=="External" ) {
						this.icon = "icons/obj/doors/airlocks/external/external.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/external/overlays.dmi";
						this.typetext = "external";
						this.icontext = "ext";
						has_solid = true;
						has_glass = false;
					} else if ( _a=="High Security" ) {
						this.icon = "icons/obj/doors/airlocks/highsec/highsec.dmi";
						this.overlays_file = "icons/obj/doors/airlocks/highsec/overlays.dmi";
						this.typetext = "highsecurity";
						this.icontext = "highsec";
						has_solid = true;
						has_glass = false;
					}

					if ( has_solid ) {
						this.airlock_type = Lang13.FindClass( "/obj/machinery/door/airlock/" + this.typetext );
					} else {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock);
					}

					if ( has_glass ) {
						this.glass_type = Lang13.FindClass( "/obj/machinery/door/airlock/glass_" + this.typetext );
					} else {
						this.glass_type = typeof(Obj_Machinery_Door_Airlock_Glass);
					}

					if ( Lang13.Bool( this.mineral ) && this.mineral != "glass" ) {
						this.mineral = null;
					}
					user.WriteMsg( "<span class='notice'>You change the paintjob on the airlock assembly.</span>" );
				}
			} else if ( A is Obj_Item_Weapon_Weldingtool && !Lang13.Bool( this.anchored ) ) {
				WT2 = A;

				if ( ((Obj_Item_Weapon_Weldingtool)WT2).remove_fuel( 0, user ) ) {
					((Ent_Static)user).visible_message( "<span class='warning'>" + user + " disassembles the airlock assembly.</span>", "You start to disassemble the airlock assembly..." );
					GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 50, 1 );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						
						if ( !((Obj_Item_Weapon_Weldingtool)WT2).isOn() ) {
							return null;
						}
						user.WriteMsg( "<span class='notice'>You disassemble the airlock assembly.</span>" );
						new Obj_Item_Stack_Sheet_Metal( GlobalFuncs.get_turf( this ), 4 );

						if ( Lang13.Bool( this.mineral ) ) {
							
							if ( this.mineral == "glass" ) {
								
								if ( this.heat_proof_finished ) {
									new Obj_Item_Stack_Sheet_Rglass( GlobalFuncs.get_turf( this ) );
								} else {
									new Obj_Item_Stack_Sheet_Glass( GlobalFuncs.get_turf( this ) );
								}
							} else {
								M = Lang13.FindClass( "/obj/item/stack/sheet/mineral/" + this.mineral );
								Lang13.Call( M, GlobalFuncs.get_turf( this ) );
								Lang13.Call( M, GlobalFuncs.get_turf( this ) );
							}
						}
						GlobalFuncs.qdel( this );
					}
				} else {
					return null;
				}
			} else if ( A is Obj_Item_Weapon_Wrench && !Lang13.Bool( this.anchored ) ) {
				door_check = true;

				foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Machinery_Door) )) {
					D = _b;
					

					if ( !D.sub_door ) {
						door_check = false;
						break;
					}
				}

				if ( door_check ) {
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
					((Ent_Static)user).visible_message( "" + user + " secures the airlock assembly to the floor.", "<span class='notice'>You start to secure the airlock assembly to the floor...</span>", "<span class='italics'>You hear wrenching.</span>" );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						
						if ( Lang13.Bool( this.anchored ) ) {
							return null;
						}
						user.WriteMsg( "<span class='notice'>You secure the airlock assembly.</span>" );
						this.name = "secured airlock assembly";
						this.anchored = 1;
					}
				} else {
					user.WriteMsg( "There is another door here!" );
				}
			} else if ( A is Obj_Item_Weapon_Wrench && Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
				((Ent_Static)user).visible_message( "" + user + " unsecures the airlock assembly from the floor.", "<span class='notice'>You start to unsecure the airlock assembly from the floor...</span>", "<span class='italics'>You hear wrenching.</span>" );

				if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
					
					if ( !Lang13.Bool( this.anchored ) ) {
						return null;
					}
					user.WriteMsg( "<span class='notice'>You unsecure the airlock assembly.</span>" );
					this.name = "airlock assembly";
					this.anchored = 0;
				}
			} else if ( A is Obj_Item_Stack_CableCoil && this.state == 0 && Lang13.Bool( this.anchored ) ) {
				C = A;

				if ( ( ((Obj_Item_Stack)C).get_amount() ??0) < 1 ) {
					user.WriteMsg( "<span class='warning'>You need one length of cable to wire the airlock assembly!</span>" );
					return null;
				}
				((Ent_Static)user).visible_message( "" + user + " wires the airlock assembly.", "<span class='notice'>You start to wire the airlock assembly...</span>" );

				if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
					
					if ( ( ((Obj_Item_Stack)C).get_amount() ??0) < 1 || this.state != 0 ) {
						return null;
					}
					C.use( 1 );
					this.state = 1;
					user.WriteMsg( "<span class='notice'>You wire the airlock assembly.</span>" );
					this.name = "wired airlock assembly";
				}
			} else if ( A is Obj_Item_Weapon_Wirecutters && this.state == 1 ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
				((Ent_Static)user).visible_message( "" + user + " cuts the wires from the airlock assembly.", "<span class='notice'>You start to cut the wires from the airlock assembly...</span>" );

				if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
					
					if ( this.state != 1 ) {
						return null;
					}
					user.WriteMsg( "<span class='notice'>You cut the wires from the airlock assembly.</span>" );
					new Obj_Item_Stack_CableCoil( GlobalFuncs.get_turf( user ), 1 );
					this.state = 0;
					this.name = "secured airlock assembly";
				}
			} else if ( A is Obj_Item_Weapon_Electronics_Airlock && this.state == 1 ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
				((Ent_Static)user).visible_message( "" + user + " installs the electronics into the airlock assembly.", "<span class='notice'>You start to install electronics into the airlock assembly...</span>" );

				if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
					
					if ( this.state != 1 ) {
						return null;
					}

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					A.loc = this;
					user.WriteMsg( "<span class='notice'>You install the airlock electronics.</span>" );
					this.state = 2;
					this.name = "near finished airlock assembly";
					this.electronics = A;
				}
			} else if ( A is Obj_Item_Weapon_Crowbar && this.state == 2 ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );
				((Ent_Static)user).visible_message( "" + user + " removes the electronics from the airlock assembly.", "<span class='notice'>You start to remove electronics from the airlock assembly...</span>" );

				if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
					
					if ( this.state != 2 ) {
						return null;
					}
					user.WriteMsg( "<span class='notice'>You remove the airlock electronics.</span>" );
					this.state = 1;
					this.name = "wired airlock assembly";
					ae = null;

					if ( !Lang13.Bool( this.electronics ) ) {
						ae = new Obj_Item_Weapon_Electronics_Airlock( this.loc );
					} else {
						ae = this.electronics;
						this.electronics = null;
						ae.loc = this.loc;
					}
				}
			} else if ( A is Obj_Item_Stack_Sheet && !Lang13.Bool( this.mineral ) ) {
				G = A;

				if ( Lang13.Bool( G ) ) {
					
					if ( ( ((Obj_Item_Stack)G).get_amount() ??0) >= 1 ) {
						
						if ( G is Obj_Item_Stack_Sheet_Rglass || G is Obj_Item_Stack_Sheet_Glass ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );
							((Ent_Static)user).visible_message( "" + user + " adds " + G.name + " to the airlock assembly.", "<span class='notice'>You start to install " + G.name + " into the airlock assembly...</span>" );

							if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
								
								if ( ( ((Obj_Item_Stack)G).get_amount() ??0) < 1 || Lang13.Bool( this.mineral ) ) {
									return null;
								}

								if ( G.type == typeof(Obj_Item_Stack_Sheet_Rglass) ) {
									user.WriteMsg( "<span class='notice'>You install reinforced glass windows into the airlock assembly.</span>" );
									this.heat_proof_finished = true;
									this.name = "near finished heat-proofed window airlock assembly";
								} else {
									user.WriteMsg( "<span class='notice'>You install regular glass windows into the airlock assembly.</span>" );
									this.name = "near finished window airlock assembly";
								}
								G.use( 1 );
								this.mineral = "glass";
								this.material = "glass";

								if ( new ByTable(new object [] { "eng", "atmo", "sec", "com", "med", "res", "min" }).Contains( this.icontext ) ) {
									this.airlock_type = Lang13.FindClass( "/obj/machinery/door/airlock/" + this.typetext );
									this.glass_type = Lang13.FindClass( "/obj/machinery/door/airlock/glass_" + this.typetext );
								} else {
									this.airlock_type = typeof(Obj_Machinery_Door_Airlock);
									this.glass_type = typeof(Obj_Machinery_Door_Airlock_Glass);
									this.typetext = "";
									this.icontext = "";
								}
							}
						} else if ( G is Obj_Item_Stack_Sheet_Mineral ) {
							M2 = G.sheettype;

							if ( ( ((Obj_Item_Stack)G).get_amount() ??0) >= 2 ) {
								GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );
								((Ent_Static)user).visible_message( "" + user + " adds " + G.name + " to the airlock assembly.", "<span class='notice'>You start to install " + G.name + " into the airlock assembly...</span>" );

								if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
									
									if ( ( ((Obj_Item_Stack)G).get_amount() ??0) < 2 || Lang13.Bool( this.mineral ) ) {
										return null;
									}
									user.WriteMsg( "<span class='notice'>You install " + M2 + " plating into the airlock assembly.</span>" );
									G.use( 2 );
									this.mineral = "" + M2;
									this.name = "near finished " + M2 + " airlock assembly";
									this.airlock_type = Lang13.FindClass( "/obj/machinery/door/airlock/" + M2 );
									this.glass_type = typeof(Obj_Machinery_Door_Airlock_Glass);
								}
							}
						}
					}
				}
			} else if ( A is Obj_Item_Weapon_Screwdriver && this.state == 2 ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
				((Ent_Static)user).visible_message( "" + user + " finishes the airlock.", "<span class='notice'>You start finishing the airlock...</span>" );

				if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
					
					if ( this.loc != null && this.state == 2 ) {
						user.WriteMsg( "<span class='notice'>You finish the airlock.</span>" );
						door = null;

						if ( this.mineral == "glass" ) {
							door = Lang13.Call( this.glass_type, this.loc );
						} else {
							door = Lang13.Call( this.airlock_type, this.loc );
						}
						door.electronics = this.electronics;
						door.heat_proof = this.heat_proof_finished;

						if ( this.electronics.one_access ) {
							door.req_one_access = this.electronics.accesses;
						} else {
							door.req_access = this.electronics.accesses;
						}

						if ( Lang13.Bool( this.created_name ) ) {
							door.name = this.created_name;
						}
						this.electronics.loc = door;
						GlobalFuncs.qdel( this );
					}
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			this.update_icon();
			return null;
		}

		// Function from file: airlock_maker.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			base.attack_hand( (object)(a), b, c );

			if ( this.maker != null ) {
				this.maker.interact();
			}
			return null;
		}

	}

}