// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_CableCoil : Obj_Item_Stack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "coil_red";
			this.max_amount = 30;
			this.amount = 30;
			this.merge_type = typeof(Obj_Item_Stack_CableCoil);
			this.item_color = "red";
			this.w_class = 2;
			this.throw_speed = 3;
			this.throw_range = 5;
			this.materials = new ByTable().Set( "$metal", 10 ).Set( "$glass", 5 );
			this.flags = 64;
			this.slot_flags = 512;
			this.attack_verb = new ByTable(new object [] { "whipped", "lashed", "disciplined", "flogged" });
			this.singular_name = "cable piece";
			this.icon = "icons/obj/power.dmi";
			this.icon_state = "coil_red";
		}

		// Function from file: cable.dm
		public Obj_Item_Stack_CableCoil ( dynamic loc = null, int? amount = null, dynamic param_color = null ) : base( (object)(loc), amount ) {
			amount = amount ?? 30;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.amount = amount;

			if ( Lang13.Bool( param_color ) ) {
				this.item_color = param_color;
			}
			this.pixel_x = Rand13.Int( -2, 2 );
			this.pixel_y = Rand13.Int( -2, 2 );
			this.update_icon();
			this.recipes = GlobalVars.cable_coil_recipes;
			return;
		}

		// Function from file: cable.dm
		public void cable_join( Obj_Structure_Cable C = null, dynamic user = null ) {
			Ent_Static U = null;
			Ent_Static T = null;
			double? dirn = null;
			double? fdirn = null;
			Obj_Structure_Cable LC = null;
			dynamic NC = null;
			Powernet newPN = null;
			double? nd1 = null;
			double? nd2 = null;
			Obj_Structure_Cable LC2 = null;

			U = user.loc;

			if ( !( U is Tile ) ) {
				return;
			}
			T = C.loc;

			if ( !( T is Tile ) || Lang13.Bool( ((dynamic)T).intact ) ) {
				return;
			}

			if ( Map13.GetDistance( C, user ) > 1 ) {
				user.WriteMsg( "<span class='warning'>You can't lay cable at a place that far away!</span>" );
				return;
			}

			if ( U == T ) {
				this.place_turf( T, user );
				return;
			}
			dirn = Map13.GetDistance( C, user );

			if ( C.d1 == dirn || C.d2 == dirn ) {
				
				if ( !Lang13.Bool( ((dynamic)U).can_have_cabling() ) ) {
					user.WriteMsg( "<span class='warning'>You can only lay cables on catwalks and plating!</span>" );
					return;
				}

				if ( Lang13.Bool( ((dynamic)U).intact ) ) {
					user.WriteMsg( "<span class='warning'>You can't lay cable there unless the floor tiles are removed!</span>" );
					return;
				} else {
					fdirn = Num13.Rotate( dirn, 180 );

					foreach (dynamic _a in Lang13.Enumerate( U, typeof(Obj_Structure_Cable) )) {
						LC = _a;
						

						if ( LC.d1 == fdirn || LC.d2 == fdirn ) {
							user.WriteMsg( "<span class='warning'>There's already a cable at that position!</span>" );
							return;
						}
					}
					NC = this.get_new_cable( U );
					NC.d1 = 0;
					NC.d2 = fdirn;
					((Ent_Static)NC).add_fingerprint();
					NC.updateicon();
					newPN = new Powernet();
					newPN.add_cable( NC );
					((Obj_Structure_Cable)NC).mergeConnectedNetworks( NC.d2 );
					((Obj_Structure_Cable)NC).mergeConnectedNetworksOnTurf();

					if ( ( ((int)( NC.d2 ??0 )) & ((int)( ( NC.d2 ??0) - 1 )) ) != 0 ) {
						((Obj_Structure_Cable)NC).mergeDiagonalsNetworks( NC.d2 );
					}
					this.use( 1 );

					if ( ((Obj_Structure_Cable)NC).shock( user, 50 ) ) {
						
						if ( Rand13.PercentChance( 50 ) ) {
							((Obj)NC).Deconstruct();
						}
					}
					return;
				}
			} else if ( C.d1 == 0 ) {
				nd1 = C.d2;
				nd2 = dirn;

				if ( ( nd1 ??0) > ( nd2 ??0) ) {
					nd1 = dirn;
					nd2 = C.d2;
				}

				foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
					LC2 = _b;
					

					if ( LC2 == C ) {
						continue;
					}

					if ( LC2.d1 == nd1 && LC2.d2 == nd2 || LC2.d1 == nd2 && LC2.d2 == nd1 ) {
						user.WriteMsg( "<span class='warning'>There's already a cable at that position!</span>" );
						return;
					}
				}
				C.cableColor( this.item_color );
				C.d1 = nd1;
				C.d2 = nd2;
				C.update_stored( 2, this.item_color );
				C.add_fingerprint();
				C.updateicon();
				C.mergeConnectedNetworks( C.d1 );
				C.mergeConnectedNetworks( C.d2 );
				C.mergeConnectedNetworksOnTurf();

				if ( ( ((int)( C.d1 ??0 )) & ((int)( ( C.d1 ??0) - 1 )) ) != 0 ) {
					C.mergeDiagonalsNetworks( C.d1 );
				}

				if ( ( ((int)( C.d2 ??0 )) & ((int)( ( C.d2 ??0) - 1 )) ) != 0 ) {
					C.mergeDiagonalsNetworks( C.d2 );
				}
				this.use( 1 );

				if ( C.shock( user, 50 ) ) {
					
					if ( Rand13.PercentChance( 50 ) ) {
						C.Deconstruct();
						return;
					}
				}
				C.denode();
				return;
			}
			return;
		}

		// Function from file: cable.dm
		public void place_turf( Ent_Static T = null, dynamic user = null ) {
			double? dirn = null;
			Obj_Structure_Cable LC = null;
			dynamic C = null;
			Powernet PN = null;

			
			if ( !( user.loc is Tile ) ) {
				return;
			}

			if ( !Lang13.Bool( ((dynamic)T).can_have_cabling() ) ) {
				user.WriteMsg( "<span class='warning'>You can only lay cables on catwalks and plating!</span>" );
				return;
			}

			if ( ( this.get_amount() ??0) < 1 ) {
				user.WriteMsg( "<span class='warning'>There is no cable left!</span>" );
				return;
			}

			if ( Map13.GetDistance( T, user ) > 1 ) {
				user.WriteMsg( "<span class='warning'>You can't lay cable at a place that far away!</span>" );
				return;
			} else {
				
				if ( user.loc == T ) {
					dirn = Lang13.DoubleNullable( user.dir );
				} else {
					dirn = Map13.GetDistance( T, user );
				}

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
					LC = _a;
					

					if ( LC.d2 == dirn && LC.d1 == 0 ) {
						user.WriteMsg( "<span class='warning'>There's already a cable at that position!</span>" );
						return;
					}
				}
				C = this.get_new_cable( T );
				C.d1 = 0;
				C.d2 = dirn;
				((Ent_Static)C).add_fingerprint( user );
				C.updateicon();
				PN = new Powernet();
				PN.add_cable( C );
				((Obj_Structure_Cable)C).mergeConnectedNetworks( C.d2 );
				((Obj_Structure_Cable)C).mergeConnectedNetworksOnTurf();

				if ( ( ((int)( C.d2 ??0 )) & ((int)( ( C.d2 ??0) - 1 )) ) != 0 ) {
					((Obj_Structure_Cable)C).mergeDiagonalsNetworks( C.d2 );
				}
				this.use( 1 );

				if ( ((Obj_Structure_Cable)C).shock( user, 50 ) ) {
					
					if ( Rand13.PercentChance( 50 ) ) {
						((Obj)C).Deconstruct();
					}
				}
			}
			return;
		}

		// Function from file: cable.dm
		public dynamic get_new_cable( Ent_Static location = null ) {
			string path = null;

			path = "/obj/structure/cable" + ( this.item_color == "red" ? "" : "/" + this.item_color );
			return Lang13.Call( path, location );
		}

		// Function from file: cable.dm
		public void give( dynamic extra = null ) {
			
			if ( ( this.amount ??0) + Convert.ToDouble( extra ) > ( this.max_amount ??0) ) {
				this.amount = this.max_amount;
			} else {
				this.amount += Convert.ToDouble( extra );
			}
			this.update_icon();
			return;
		}

		// Function from file: cable.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic new_cable = null;

			new_cable = base.attack_hand( (object)(a), b, c );

			if ( new_cable is Obj_Item_Stack_CableCoil ) {
				new_cable.item_color = this.item_color;
				new_cable.update_icon();
			}
			return null;
		}

		// Function from file: cable.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( !Lang13.Bool( this.item_color ) ) {
				this.item_color = Rand13.Pick(new object [] { "red", "yellow", "blue", "green" });
			}

			if ( this.amount == 1 ) {
				this.icon_state = "coil_" + this.item_color + "1";
				this.name = "cable piece";
			} else if ( this.amount == 2 ) {
				this.icon_state = "coil_" + this.item_color + "2";
				this.name = "cable piece";
			} else {
				this.icon_state = "coil_" + this.item_color;
				this.name = "cable coil";
			}
			return false;
		}

		// Function from file: cable.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			Obj_Item_Organ_Limb affecting = null;

			
			if ( !( M is Mob_Living_Carbon_Human ) ) {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			affecting = ((Mob_Living_Carbon_Human)M).get_organ( GlobalFuncs.check_zone( user.zone_selected ) );

			if ( affecting.status == 2 ) {
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " starts to fix some of the wires in " + M + "'s " + affecting.getDisplayName() + ".</span>", "<span class='notice'>You start fixing some of the wires in " + M + "'s " + affecting.getDisplayName() + ".</span>" );

				if ( !GlobalFuncs.do_mob( user, M, 50 ) ) {
					return false;
				}
				GlobalFuncs.item_heal_robotic( M, user, 0, 5 );
				this.use( 1 );
				return false;
			} else {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
		}

		// Function from file: cable.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Bed_Stool), user.loc ) ) ) {
				user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is making a noose with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			} else {
				user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is strangling " ).himself_herself_itself_themself().str( " with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			}
			return 8;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.WriteMsg( "<span class='warning'>This object does not contain enough materials to work with.</span>" );
			return;
		}

	}

}