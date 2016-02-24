// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_ConstructableFrame_MachineFrame : Obj_Machinery_ConstructableFrame {

		public Obj_Machinery_ConstructableFrame_MachineFrame ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: constructable_frame.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic C = null;
			Obj_Item_Stack_Sheet_Metal M = null;
			dynamic B = null;
			Obj_Item_Stack_CableCoil A2 = null;
			Ent_Dynamic A3 = null;
			bool component_check = false;
			dynamic R = null;
			dynamic new_machine = null;
			Obj O = null;
			Obj O2 = null;
			dynamic replacer = null;
			ByTable added_components = null;
			dynamic part_list = null;
			Obj_Item_Weapon_StockParts co = null;
			dynamic path = null;
			dynamic part = null;
			Obj_Item_Weapon_StockParts part2 = null;
			dynamic I = null;
			dynamic CP = null;
			dynamic cable_color = null;
			Obj_Item_Stack_CableCoil CC = null;

			
			if ( A.crit_fail ) {
				user.WriteMsg( "<span class='warning'>This part is faulty, you cannot add this to the machine!</span>" );
				return null;
			}

			switch ((int)( this.state )) {
				case 1:
					
					if ( A is Obj_Item_Weapon_Circuitboard ) {
						user.WriteMsg( "<span class='warning'>The frame needs wiring first!</span>" );
						return null;
					}

					if ( A is Obj_Item_Stack_CableCoil ) {
						C = A;

						if ( ( ((Obj_Item_Stack)C).get_amount() ??0) >= 5 ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
							user.WriteMsg( "<span class='notice'>You start to add cables to the frame...</span>" );

							if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
								
								if ( ( ((Obj_Item_Stack)C).get_amount() ??0) >= 5 && this.state == 1 ) {
									C.use( 5 );
									user.WriteMsg( "<span class='notice'>You add cables to the frame.</span>" );
									this.state = 2;
									this.icon_state = "box_1";
								}
							}
						} else {
							user.WriteMsg( "<span class='warning'>You need five length of cable to wire the frame!</span>" );
							return null;
						}
					}

					if ( A is Obj_Item_Weapon_Screwdriver && !Lang13.Bool( this.anchored ) ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );
						((Ent_Static)user).visible_message( "<span class='warning'>" + user + " disassembles the frame.</span>", "<span class='notice'>You start to disassemble the frame...</span>", "You hear banging and clanking." );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( this.state == 1 ) {
								user.WriteMsg( "<span class='notice'>You disassemble the frame.</span>" );
								M = new Obj_Item_Stack_Sheet_Metal( this.loc, 5 );
								M.add_fingerprint( user );
								GlobalFuncs.qdel( this );
							}
						}
					}

					if ( A is Obj_Item_Weapon_Wrench ) {
						user.WriteMsg( "<span class='notice'>You start " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "securing " + this.name + "...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							
							if ( this.state == 1 ) {
								user.WriteMsg( "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "secure " + this.name + ".</span>" );
								this.anchored = !Lang13.Bool( this.anchored );
							}
						}
					}
					break;
				case 2:
					
					if ( A is Obj_Item_Weapon_Wrench ) {
						user.WriteMsg( "<span class='notice'>You start " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "securing " + this.name + "...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );

						if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
							user.WriteMsg( "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "secure " + this.name + ".</span>" );
							this.anchored = !Lang13.Bool( this.anchored );
						}
					}

					if ( A is Obj_Item_Weapon_Circuitboard ) {
						
						if ( !Lang13.Bool( this.anchored ) ) {
							user.WriteMsg( "<span class='warning'>The frame needs to be secured first!</span>" );
							return null;
						}
						B = A;

						if ( B.board_type == "machine" ) {
							
							if ( !Lang13.Bool( user.drop_item() ) ) {
								return null;
							}
							GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
							user.WriteMsg( "<span class='notice'>You add the circuit board to the frame.</span>" );
							this.circuit = A;
							A.loc = this;
							this.icon_state = "box_2";
							this.state = 3;
							this.components = new ByTable();
							this.req_components = this.circuit.req_components.Copy();
							this.update_namelist();
							this.update_req_desc();
						} else {
							user.WriteMsg( "<span class='warning'>This frame does not accept circuit boards of this type!</span>" );
						}
					}

					if ( A is Obj_Item_Weapon_Wirecutters ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 50, 1 );
						user.WriteMsg( "<span class='notice'>You remove the cables.</span>" );
						this.state = 1;
						this.icon_state = "box_0";
						A2 = new Obj_Item_Stack_CableCoil( this.loc );
						A2.amount = 5;
					}
					break;
				case 3:
					
					if ( A is Obj_Item_Weapon_Crowbar ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 50, 1 );
						this.state = 2;
						this.circuit.loc = this.loc;
						this.components.Remove( this.circuit );
						this.circuit = null;

						if ( this.components.len == 0 ) {
							user.WriteMsg( "<span class='notice'>You remove the circuit board.</span>" );
						} else {
							user.WriteMsg( "<span class='notice'>You remove the circuit board and other components.</span>" );

							foreach (dynamic _a in Lang13.Enumerate( this.components, typeof(Ent_Dynamic) )) {
								A3 = _a;
								
								A3.loc = this.loc;
							}
						}
						this.desc = Lang13.Initial( this, "desc" );
						this.req_components = null;
						this.components = null;
						this.icon_state = "box_1";
					}

					if ( A is Obj_Item_Weapon_Screwdriver ) {
						component_check = true;

						foreach (dynamic _b in Lang13.Enumerate( this.req_components )) {
							R = _b;
							

							if ( Convert.ToDouble( this.req_components[R] ) > 0 ) {
								component_check = false;
								break;
							}
						}

						if ( component_check ) {
							GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );
							new_machine = Lang13.Call( this.circuit.build_path, this.loc, 1 );
							((Obj_Machinery)new_machine).construction();

							foreach (dynamic _c in Lang13.Enumerate( new_machine.component_parts, typeof(Obj) )) {
								O = _c;
								
								GlobalFuncs.qdel( O );
							}
							new_machine.component_parts = new ByTable();

							foreach (dynamic _d in Lang13.Enumerate( this, typeof(Obj) )) {
								O2 = _d;
								
								O2.loc = null;
								new_machine.component_parts.Add( O2 );
							}
							this.circuit.loc = null;
							((Obj_Machinery)new_machine).RefreshParts();
							GlobalFuncs.qdel( this );
						}
					}

					if ( A is Obj_Item_Weapon_Storage_PartReplacer && A.contents.len != 0 && this.get_req_components_amt() != 0 ) {
						replacer = A;
						added_components = new ByTable();
						part_list = new ByTable();

						foreach (dynamic _e in Lang13.Enumerate( replacer, typeof(Obj_Item_Weapon_StockParts) )) {
							co = _e;
							
							part_list += co;
						}
						part_list = GlobalFuncs.sortTim( part_list, typeof(GlobalFuncs).GetMethod( "cmp_rped_sort" ) );

						foreach (dynamic _f in Lang13.Enumerate( this.req_components )) {
							path = _f;
							

							while (Convert.ToDouble( this.req_components[path] ) > 0 && Lang13.Bool( Lang13.FindIn( path, part_list ) )) {
								part = Lang13.FindIn( path, part_list );

								if ( !part.crit_fail ) {
									added_components[part] = path;
									((Obj_Item_Weapon_Storage)replacer).remove_from_storage( part, this );
									this.req_components[path]--;
									part_list -= part;
								}
							}
						}

						foreach (dynamic _g in Lang13.Enumerate( added_components, typeof(Obj_Item_Weapon_StockParts) )) {
							part2 = _g;
							
							this.components.Add( part2 );
							user.WriteMsg( "<span class='notice'>" + part2.name + " applied.</span>" );
						}
						((Obj_Item_Weapon_Storage_PartReplacer)replacer).play_rped_sound();
						this.update_req_desc();
						return null;
					}

					if ( A is Obj_Item && this.get_req_components_amt() != 0 ) {
						
						foreach (dynamic _h in Lang13.Enumerate( this.req_components )) {
							I = _h;
							

							if ( Lang13.Bool( I.IsInstanceOfType( A ) ) && Convert.ToDouble( this.req_components[I] ) > 0 ) {
								
								if ( A is Obj_Item_Stack_CableCoil ) {
									CP = A;
									cable_color = CP.item_color;

									if ( Lang13.Bool( CP.use( 1 ) ) ) {
										CC = new Obj_Item_Stack_CableCoil( this, 1, cable_color );
										this.components.Add( CC );
										this.req_components[I]--;
										this.update_req_desc();
									} else {
										user.WriteMsg( "<span class='warning'>You need more cable!</span>" );
									}
									return null;
								}

								if ( !Lang13.Bool( user.drop_item() ) ) {
									break;
								}
								A.loc = this;
								this.components.Add( A );
								this.req_components[I]--;
								this.update_req_desc();
								return 1;
							}
						}
						user.WriteMsg( "<span class='warning'>You cannot add that to the machine!</span>" );
						return 0;
					}
					break;
			}
			return null;
		}

	}

}