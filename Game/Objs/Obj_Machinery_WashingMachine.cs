// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_WashingMachine : Obj_Machinery {

		public int wash_state = 1;
		public bool hacked = true;
		public bool gibs_ready = false;
		public dynamic crayon = null;
		public double speed_coefficient = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.machine_flags = 10;
			this.icon = "icons/obj/machines/washing_machine.dmi";
			this.icon_state = "wm_10";
		}

		// Function from file: washing_machine.dm
		public Obj_Machinery_WashingMachine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { new Obj_Item_Weapon_Circuitboard_WashingMachine(), new Obj_Item_Weapon_StockParts_MatterBin(), new Obj_Item_Weapon_StockParts_Manipulator() });
			this.RefreshParts();
			return;
		}

		// Function from file: washing_machine.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Dynamic O = null;
			Ent_Dynamic O2 = null;
			dynamic M = null;
			Ent_Dynamic O3 = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return 1;
			}

			switch ((int)( this.wash_state )) {
				case 1:
					this.wash_state = 2;
					break;
				case 2:
					this.wash_state = 1;

					foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
						O = _a;
						
						O.loc = this.loc;
					}
					break;
				case 3:
					this.wash_state = 4;
					break;
				case 4:
					this.wash_state = 3;

					foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
						O2 = _b;
						
						O2.loc = this.loc;
					}
					this.crayon = null;
					this.wash_state = 1;
					break;
				case 5:
					GlobalFuncs.to_chat( a, new Txt( "<span class='warning'>" ).The( this ).item().str( " is busy.</span>" ).ToString() );
					break;
				case 6:
					this.wash_state = 7;
					break;
				case 7:
					
					if ( this.gibs_ready ) {
						this.gibs_ready = false;

						if ( Lang13.Bool( Lang13.FindIn( typeof(Mob), this.contents ) ) ) {
							M = Lang13.FindIn( typeof(Mob), this.contents );
							((Mob)M).gib();
						}
					}

					foreach (dynamic _c in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
						O3 = _c;
						
						O3.loc = this.loc;
					}
					this.crayon = null;
					this.wash_state = 1;
					break;
			}
			this.update_icon();
			return null;
		}

		// Function from file: washing_machine.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic G = null;

			
			if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				this.update_icon();
				return 1;
			} else if ( a is Obj_Item_Toy_Crayon || a is Obj_Item_Weapon_Stamp ) {
				
				if ( new ByTable(new object [] { 1, 3, 6 }).Contains( this.wash_state ) ) {
					
					if ( !Lang13.Bool( this.crayon ) ) {
						
						if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
							this.crayon = a;
						}
					}
				}
			} else if ( a is Obj_Item_Weapon_Grab ) {
				
				if ( this.wash_state == 1 && this.hacked ) {
					G = a;

					if ( G.assailant is Mob_Living_Carbon_Human && G.affecting is Mob_Living_SimpleAnimal_Corgi ) {
						G.affecting.loc = this;
						GlobalFuncs.qdel( G );
						G = null;
						this.wash_state = 3;
					}
				}
			} else if ( a is Obj_Item_Stack_Sheet_Hairlesshide || a is Obj_Item_Clothing_Under || a is Obj_Item_Clothing_Mask || a is Obj_Item_Clothing_Head || a is Obj_Item_Clothing_Gloves || a is Obj_Item_Clothing_Shoes || a is Obj_Item_Clothing_Suit || a is Obj_Item_Stack_CableCoil || a is Obj_Item_Weapon_Bedsheet ) {
				
				if ( a is Obj_Item_Clothing_Suit_Space ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Suit_Syndicatefake ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Suit_CyborgSuit ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Suit_BombSuit ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Suit_Armor ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Suit_Armor ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Mask_Gas ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Mask_Cigarette ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Head_Syndicatefake ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( a is Obj_Item_Clothing_Head_Helmet ) {
					GlobalFuncs.to_chat( b, "This item does not fit." );
					return null;
				}

				if ( this.contents.len < 5 ) {
					
					if ( new ByTable(new object [] { 1, 3 }).Contains( this.wash_state ) ) {
						
						if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
							this.wash_state = 3;
						}
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>You can't put the item in right now.</span>" );
					}
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).The( this ).item().str( " is full.</span>" ).ToString() );
				}
			}
			this.update_icon();
			return null;
		}

		// Function from file: washing_machine.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "wm_" + this.wash_state + this.panel_open;
			return null;
		}

		// Function from file: washing_machine.dm
		public override void AltClick( Mob user = null ) {
			
			if ( !Task13.User.incapacitated() && this.Adjacent( Task13.User ) && Lang13.Bool( Task13.User.dexterity_check() ) ) {
				this.__CallVerb("Start Washing" );
				return;
			}
			base.AltClick( user ); return;
		}

		// Function from file: washing_machine.dm
		public override dynamic RefreshParts(  ) {
			int manipcount = 0;
			Obj_Item_Weapon_StockParts SP = null;

			manipcount = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts) )) {
				SP = _a;
				

				if ( SP is Obj_Item_Weapon_StockParts_Manipulator ) {
					manipcount += SP.rating;
				}
			}
			this.speed_coefficient = 1 / manipcount;
			return null;
		}

		// Function from file: washing_machine.dm
		[Verb]
		[VerbInfo( name: "Climb out", group: "Object", access: VerbAccess.InUserLocation, range: 127 )]
		public void climb_out(  ) {
			Task13.Sleep( 20 );

			if ( new ByTable(new object [] { 1, 3, 6 }).Contains( this.wash_state ) ) {
				Task13.User.loc = this.loc;
			}
			return;
		}

		// Function from file: washing_machine.dm
		[Verb]
		[VerbInfo( name: "Start Washing", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void start(  ) {
			Ent_Static A = null;
			Obj_Item I = null;
			Obj_Item_Stack_Sheet_Hairlesshide HH = null;
			Obj_Item_Stack_Sheet_Wetleather WL = null;
			string color = null;
			dynamic CR = null;
			dynamic ST = null;
			string new_jumpsuit_icon_state = null;
			dynamic new_jumpsuit_item_state = null;
			string new_jumpsuit_name = null;
			string new_glove_icon_state = null;
			dynamic new_glove_item_state = null;
			string new_glove_name = null;
			string new_shoe_icon_state = null;
			string new_shoe_name = null;
			string new_sheet_icon_state = null;
			string new_sheet_name = null;
			string new_softcap_icon_state = null;
			string new_softcap_name = null;
			bool? ccoil_test = null;
			string new_desc = null;
			dynamic T = null;
			dynamic J = null;
			dynamic T2 = null;
			dynamic G = null;
			dynamic T3 = null;
			dynamic S = null;
			dynamic T4 = null;
			dynamic B = null;
			dynamic T5 = null;
			dynamic H = null;
			dynamic T6 = null;
			dynamic test = null;
			Obj_Item_Clothing_Under J2 = null;
			Obj_Item_Clothing_Gloves G2 = null;
			Obj_Item_Clothing_Shoes S2 = null;
			Obj_Item_Weapon_Bedsheet B2 = null;
			Obj_Item_Clothing_Head_Soft H2 = null;
			Obj_Item_Stack_CableCoil H3 = null;

			
			if ( this.wash_state != 4 ) {
				GlobalFuncs.to_chat( Task13.User, new Txt().The( this ).item().str( " cannot run in this state." ).ToString() );
				return;
			}

			if ( Lang13.Bool( Lang13.FindIn( typeof(Mob), this.contents ) ) ) {
				this.wash_state = 8;
			} else {
				this.wash_state = 5;
			}
			this.update_icon();
			Task13.Sleep( ((int)( this.speed_coefficient * 200 )) );

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Static) )) {
				A = _a;
				
				A.clean_blood();
			}

			foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				I = _b;
				
				I.decontaminate();
			}

			foreach (dynamic _c in Lang13.Enumerate( this.contents, typeof(Obj_Item_Stack_Sheet_Hairlesshide) )) {
				HH = _c;
				
				WL = new Obj_Item_Stack_Sheet_Wetleather( this );
				WL.amount = HH.amount;
				GlobalFuncs.qdel( HH );
				HH = null;
			}

			if ( Lang13.Bool( this.crayon ) ) {
				color = null;

				if ( this.crayon is Obj_Item_Toy_Crayon ) {
					CR = this.crayon;
					color = CR.colourName;
				} else if ( this.crayon is Obj_Item_Weapon_Stamp ) {
					ST = this.crayon;
					color = ST._color;
				}

				if ( Lang13.Bool( color ) ) {
					new_jumpsuit_icon_state = "";
					new_jumpsuit_item_state = "";
					new_jumpsuit_name = "";
					new_glove_icon_state = "";
					new_glove_item_state = "";
					new_glove_name = "";
					new_shoe_icon_state = "";
					new_shoe_name = "";
					new_sheet_icon_state = "";
					new_sheet_name = "";
					new_softcap_icon_state = "";
					new_softcap_name = "";
					ccoil_test = null;
					new_desc = "The colors are a bit dodgy.";

					foreach (dynamic _d in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Under) ) )) {
						T = _d;
						
						J = Lang13.Call( T );

						if ( color == J._color ) {
							new_jumpsuit_icon_state = J.icon_state;
							new_jumpsuit_item_state = J.item_state;
							new_jumpsuit_name = J.name;
							GlobalFuncs.qdel( J );
							J = null;
							break;
						}
						GlobalFuncs.qdel( J );
						J = null;
					}

					foreach (dynamic _e in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Gloves) ) )) {
						T2 = _e;
						
						G = Lang13.Call( T2 );

						if ( color == G._color ) {
							new_glove_icon_state = G.icon_state;
							new_glove_item_state = G.item_state;
							new_glove_name = G.name;
							GlobalFuncs.qdel( G );
							G = null;
							break;
						}
						GlobalFuncs.qdel( G );
						G = null;
					}

					foreach (dynamic _f in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Shoes) ) )) {
						T3 = _f;
						
						S = Lang13.Call( T3 );

						if ( color == S._color ) {
							new_shoe_icon_state = S.icon_state;
							new_shoe_name = S.name;
							GlobalFuncs.qdel( S );
							S = null;
							break;
						}
						GlobalFuncs.qdel( S );
						S = null;
					}

					foreach (dynamic _g in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Weapon_Bedsheet) ) )) {
						T4 = _g;
						
						B = Lang13.Call( T4 );

						if ( color == B._color ) {
							new_sheet_icon_state = B.icon_state;
							new_sheet_name = B.name;
							GlobalFuncs.qdel( B );
							B = null;
							break;
						}
						GlobalFuncs.qdel( B );
						B = null;
					}

					foreach (dynamic _h in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Head_Soft) ) )) {
						T5 = _h;
						
						H = Lang13.Call( T5 );

						if ( color == H._color ) {
							new_softcap_icon_state = H.icon_state;
							new_softcap_name = H.name;
							GlobalFuncs.qdel( H );
							H = null;
							break;
						}
						GlobalFuncs.qdel( H );
						H = null;
					}

					foreach (dynamic _i in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Stack_CableCoil) ) )) {
						T6 = _i;
						
						test = Lang13.Call( T6 );

						if ( test._color == color ) {
							ccoil_test = true;
							GlobalFuncs.qdel( test );
							test = null;
							break;
						}
						GlobalFuncs.qdel( test );
						test = null;
					}

					if ( Lang13.Bool( new_jumpsuit_icon_state ) && Lang13.Bool( new_jumpsuit_item_state ) && Lang13.Bool( new_jumpsuit_name ) ) {
						
						foreach (dynamic _j in Lang13.Enumerate( this.contents, typeof(Obj_Item_Clothing_Under) )) {
							J2 = _j;
							
							J2.item_state = new_jumpsuit_item_state;
							J2.icon_state = new_jumpsuit_icon_state;
							J2._color = color;
							J2.name = new_jumpsuit_name;
							J2.desc = new_desc;
						}
					}

					if ( Lang13.Bool( new_glove_icon_state ) && Lang13.Bool( new_glove_item_state ) && Lang13.Bool( new_glove_name ) ) {
						
						foreach (dynamic _k in Lang13.Enumerate( this.contents, typeof(Obj_Item_Clothing_Gloves) )) {
							G2 = _k;
							
							G2.item_state = new_glove_item_state;
							G2.icon_state = new_glove_icon_state;
							G2._color = color;
							G2.name = new_glove_name;

							if ( !( G2 is Obj_Item_Clothing_Gloves_Black_Thief ) ) {
								G2.desc = new_desc;
							}
						}
					}

					if ( Lang13.Bool( new_shoe_icon_state ) && Lang13.Bool( new_shoe_name ) ) {
						
						foreach (dynamic _l in Lang13.Enumerate( this.contents, typeof(Obj_Item_Clothing_Shoes) )) {
							S2 = _l;
							

							if ( S2.chained == true ) {
								S2.chained = false;
								S2.slowdown = -1;
								new Obj_Item_Weapon_Handcuffs( this );
							}
							S2.icon_state = new_shoe_icon_state;
							S2._color = color;
							S2.name = new_shoe_name;
							S2.desc = new_desc;
						}
					}

					if ( Lang13.Bool( new_sheet_icon_state ) && Lang13.Bool( new_sheet_name ) ) {
						
						foreach (dynamic _m in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_Bedsheet) )) {
							B2 = _m;
							
							B2.icon_state = new_sheet_icon_state;
							B2._color = color;
							B2.name = new_sheet_name;
							B2.desc = new_desc;
						}
					}

					if ( Lang13.Bool( new_softcap_icon_state ) && Lang13.Bool( new_softcap_name ) ) {
						
						foreach (dynamic _n in Lang13.Enumerate( this.contents, typeof(Obj_Item_Clothing_Head_Soft) )) {
							H2 = _n;
							
							H2.icon_state = new_softcap_icon_state;
							H2._color = color;
							H2.name = new_softcap_name;
							H2.desc = new_desc;
						}
					}

					if ( ccoil_test == true ) {
						
						foreach (dynamic _o in Lang13.Enumerate( this.contents, typeof(Obj_Item_Stack_CableCoil) )) {
							H3 = _o;
							
							H3._color = color;
							H3.icon_state = "coil_" + color;
						}
					}
				}
				GlobalFuncs.qdel( this.crayon );
				this.crayon = null;
			}

			if ( Lang13.Bool( Lang13.FindIn( typeof(Mob), this.contents ) ) ) {
				this.wash_state = 7;
				this.gibs_ready = true;
			} else {
				this.wash_state = 4;
			}
			this.update_icon();
			return;
		}

	}

}