// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public string plantname = null;
		public int potency = -1;
		public Seed seed = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/harvest.dmi";
		}

		// Function from file: grown.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ( dynamic newloc = null, dynamic newpotency = null ) : base( (object)(newloc) ) {
			
			if ( !( newpotency == null ) ) {
				this.potency = Convert.ToInt32( newpotency );
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Clothing_Mask_Cigarette_Blunt_Rolled B = null;

			
			if ( a is Obj_Item_Weapon_Paper ) {
				GlobalFuncs.qdel( a );
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You roll a blunt out of " ).the( this ).item().str( ".</span>" ).ToString() );
				B = new Obj_Item_Clothing_Mask_Cigarette_Blunt_Rolled( this.loc );
				B.name = "" + this + " blunt";
				((Reagents)this.reagents).trans_to( B, this.reagents.total_volume );
				((Mob)b).put_in_hands( B );
				((Mob)b).drop_from_inventory( this );
				GlobalFuncs.qdel( this );
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: grown.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string traits = null;

			base.examine( (object)(user), size );

			if ( !( this.seed != null ) ) {
				return null;
			}
			traits = "";

			if ( this.seed.stinging != 0 ) {
				traits += "<span class='alert'>It's covered in tiny stingers.</span> ";
			}

			if ( this.seed.thorny != 0 ) {
				traits += "<span class='alert'>It's covered in sharp thorns.</span> ";
			}

			if ( this.seed.juicy == 2 ) {
				traits += "It looks ripe and excessively juicy. ";
			}

			if ( this.seed.teleporting != 0 ) {
				traits += "It seems to be spatially unstable. ";
			}

			if ( Lang13.Bool( traits ) ) {
				GlobalFuncs.to_chat( user, traits );
			}
			return null;
		}

		// Function from file: grown.dm
		public override void On_Consume( dynamic user = null, dynamic reagentreference = null ) {
			dynamic affecting = null;

			
			if ( this.seed.thorny != 0 && user is Mob_Living_Carbon_Human ) {
				affecting = ((Mob_Living_Carbon_Human)user).get_organ( "head" );

				if ( Lang13.Bool( affecting ) ) {
					
					if ( this.thorns_apply_damage( user, affecting ) ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='danger'>Your mouth is cut by " ).the( this ).item().str( "'s sharp thorns!</span>" ).ToString() );
					}
				}
			}
			base.On_Consume( (object)(user), (object)(reagentreference) );
			return;
		}

		// Function from file: grown.dm
		public override bool pickup( Mob user = null ) {
			Mob H = null;
			dynamic affecting = null;

			base.pickup( user );

			if ( !( this.seed != null ) ) {
				return false;
			}

			if ( this.seed.thorny != 0 || this.seed.stinging != 0 ) {
				H = user;

				if ( !( H is Mob_Living_Carbon_Human ) ) {
					return false;
				}

				if ( Lang13.Bool( ((dynamic)H).check_body_part_coverage( 1536 ) ) ) {
					return false;
				}
				affecting = ((dynamic)H).get_organ( Rand13.Pick(new object [] { "r_hand", "l_hand" }) );

				if ( !Lang13.Bool( affecting ) || !((Organ_External)affecting).is_organic() ) {
					return false;
				}

				if ( this.stinging_apply_reagents( H ) ) {
					GlobalFuncs.to_chat( H, new Txt( "<span class='danger'>You are stung by " ).the( this ).item().str( "!</span>" ).ToString() );
					this.potency -= Rand13.Int( 1, ((int)( this.potency / 3 + 1 )) );
				}

				if ( this.thorns_apply_damage( H, affecting ) ) {
					GlobalFuncs.to_chat( H, new Txt( "<span class='danger'>You are prickled by the sharp thorns on " ).the( this ).item().str( "!</span>" ).ToString() );
					Task13.Schedule( 3, (Task13.Closure)(() => {
						
						if ( Lang13.Bool( ((dynamic)H).species ) && !Lang13.Bool( ((dynamic)H).species.flags & 8 ) ) {
							H.drop_item( this );
						}
						return;
					}));
				}
			}
			return false;
		}

		// Function from file: grown.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic H = null;
			dynamic affecting = null;

			base.Crossed( O, (object)(X) );

			if ( !( this.seed != null ) ) {
				return null;
			}

			if ( !( O is Mob_Living_Carbon ) ) {
				return null;
			}

			if ( !Lang13.Bool( ((dynamic)O).on_foot() ) ) {
				return null;
			}

			if ( this.seed.thorny != 0 || this.seed.stinging != 0 ) {
				
				if ( O is Mob_Living_Carbon_Human ) {
					H = O;

					if ( !Lang13.Bool( ((dynamic)H).check_body_part_coverage( 96 ) ) ) {
						affecting = ((dynamic)H).get_organ( Rand13.Pick(new object [] { "l_foot", "r_foot" }) );

						if ( Lang13.Bool( affecting ) && ((Organ_External)affecting).is_organic() ) {
							
							if ( this.thorns_apply_damage( O, affecting ) ) {
								GlobalFuncs.to_chat( H, new Txt( "<span class='danger'>You step on " ).the( this ).item().str( "'s sharp thorns!</span>" ).ToString() );

								if ( Lang13.Bool( ((dynamic)H).species ) && !Lang13.Bool( ((dynamic)H).species.flags & 8 ) ) {
									((dynamic)H).Weaken( 3 );
								}
							}

							if ( this.stinging_apply_reagents( O ) ) {
								GlobalFuncs.to_chat( H, new Txt( "<span class='danger'>Your step on " ).the( this ).item().str( "'s stingers!</span>" ).ToString() );
								this.potency -= Rand13.Int( 1, ((int)( this.potency / 3 + 1 )) );
							}
						}
					}
				}
			}

			if ( this.seed.juicy == 2 ) {
				
				if ( Lang13.Bool( ((dynamic)O).Slip( 3, 2 ) ) ) {
					GlobalFuncs.to_chat( O, "<span class='notice'>You slipped on the " + this.name + "!</span>" );
					this.do_splat_effects( O );
				}
			}
			return null;
		}

		// Function from file: grown.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			bool? _default = null;

			bool reagentlist = false;

			
			if ( user.a_intent == "hurt" ) {
				_default = this.handle_attack( this, M, user, def_zone );

				if ( this.seed.stinging != 0 ) {
					
					if ( ((Mob_Living)M).getarmor( def_zone, "melee" ) < 5 ) {
						reagentlist = this.stinging_apply_reagents( M );

						if ( reagentlist ) {
							GlobalFuncs.to_chat( M, new Txt( "<span class='danger'>You are stung by " ).the( this ).item().str( "!</span>" ).ToString() );
							GlobalFuncs.add_attacklogs( user, M, "stung", this, "Reagents: " + GlobalFuncs.english_list( this.seed.get_reagent_names() ), true );
						}
					}
					GlobalFuncs.to_chat( user, new Txt( "<span class='alert'>Some of " ).the( this ).item().str( "'s stingers break off in the hit!</span>" ).ToString() );
					this.potency -= Rand13.Int( 1, ((int)( this.potency / 3 + 1 )) );
				}
				this.do_splat_effects( M );
				return _default;
			}
			return base.attack( (object)(M), (object)(user), def_zone, eat_override );
		}

		// Function from file: grown.dm
		public bool do_fruit_teleport( dynamic hit_atom = null, Mob M = null, int potency = 0 ) {
			ZLevel L = null;
			double outer_teleport_radius = 0;
			double inner_teleport_radius = 0;
			Effect_Effect_System_SparkSpread s = null;
			ByTable turfs = null;
			dynamic T = null;
			ByTable turfs_to_pick_from = null;
			dynamic T2 = null;
			dynamic picked = null;
			dynamic A = null;

			L = GlobalFuncs.get_z_level( this );

			if ( !( L != null ) || L.teleJammed ) {
				return false;
			}
			outer_teleport_radius = potency / 10;
			inner_teleport_radius = potency / 15;

			if ( inner_teleport_radius < 1 ) {
				return false;
			}
			s = new Effect_Effect_System_SparkSpread();
			turfs = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.trange( outer_teleport_radius, GlobalFuncs.get_turf( hit_atom ) ) )) {
				T = _a;
				

				if ( Map13.GetDistance( T, hit_atom ) <= inner_teleport_radius ) {
					continue;
				}

				if ( GlobalFuncs.is_blocked_turf( T ) || T is Tile_Space ) {
					continue;
				}

				if ( Convert.ToDouble( T.x ) > Game13.map_size_x - outer_teleport_radius || Convert.ToDouble( T.x ) < outer_teleport_radius ) {
					continue;
				}

				if ( Convert.ToDouble( T.y ) > Game13.map_size_y - outer_teleport_radius || Convert.ToDouble( T.y ) < outer_teleport_radius ) {
					continue;
				}
				turfs.Add( T );
			}

			if ( !( turfs.len != 0 ) ) {
				turfs_to_pick_from = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.trange( outer_teleport_radius, GlobalFuncs.get_turf( hit_atom ) ) )) {
					T2 = _b;
					

					if ( Map13.GetDistance( T2, hit_atom ) > inner_teleport_radius ) {
						turfs_to_pick_from.Add( T2 );
					}
				}
				turfs.Add( Rand13.PickFromTable( turfs_to_pick_from.Contains( typeof(Tile) ) ) );
			}
			picked = Rand13.PickFromTable( turfs );

			if ( !( picked is Tile ) ) {
				return false;
			}

			switch ((int)( Rand13.Int( 1, 2 ) )) {
				case 1:
					s.set_up( 3, 1, M );
					s.start();
					new Obj_Effect_Decal_Cleanable_MoltenItem( M.loc );
					M.forceMove( picked );
					Task13.Schedule( 0, (Task13.Closure)(() => {
						s.set_up( 3, 1, M );
						s.start();
						return;
					}));
					break;
				case 2:
					s.set_up( 3, 1, hit_atom );
					s.start();
					new Obj_Effect_Decal_Cleanable_MoltenItem( GlobalFuncs.get_turf( hit_atom ) );

					foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.get_turf( hit_atom ) )) {
						A = _c;
						
						((Ent_Dynamic)A).forceMove( picked );
						Task13.Schedule( 0, (Task13.Closure)(() => {
							s.set_up( 3, 1, A );
							s.start();
							return;
						}));
					}
					break;
			}
			return true;
		}

		// Function from file: grown.dm
		public bool stinging_apply_reagents( dynamic H = null ) {
			bool _default = false;

			double? injecting = null;
			dynamic rid = null;

			
			if ( !( this.seed.stinging != 0 ) ) {
				return false;
			}

			if ( !Lang13.Bool( this.reagents ) || ( this.reagents.total_volume ??0) <= 0 ) {
				return false;
			}

			if ( !( this.seed.chems != null ) || !( this.seed.chems.len != 0 ) ) {
				return false;
			}
			injecting = ( 1 <= 3 ? 3 : ( 1 >= this.potency / 10 ? this.potency / 10 : 1 ) );

			foreach (dynamic _a in Lang13.Enumerate( this.seed.chems )) {
				rid = _a;
				
				((Reagents)this.reagents).trans_id_to( H, rid, injecting );
				_default = true;
			}
			return _default;
		}

		// Function from file: grown.dm
		public bool thorns_apply_damage( dynamic H = null, dynamic affecting = null ) {
			
			if ( !( this.seed.thorny != 0 ) || !Lang13.Bool( affecting ) ) {
				return false;
			}
			((Organ_External)affecting).take_damage( this.seed.carnivorous * 3 + 5, 0, false, "plant thorns" );
			((Mob_Living)H).UpdateDamageIcon();
			return true;
		}

		// Function from file: grown.dm
		public bool splat_reagent_reaction( dynamic T = null ) {
			Ent_Static A = null;

			
			if ( ( this.reagents.total_volume ??0) > 0 ) {
				((Reagents)this.reagents).reaction( T );

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Static) )) {
					A = _a;
					
					((Reagents)this.reagents).reaction( A );
				}
				return true;
			}
			return false;
		}

		// Function from file: grown.dm
		public bool splat_decal( dynamic T = null ) {
			Game_Data S = null;

			S = GlobalFuncs.getFromPool( this.seed.splat_type, T );
			((dynamic)S).New( ((dynamic)S).loc );

			if ( this.seed.splat_type == typeof(Obj_Effect_Decal_Cleanable_FruitSmudge) ) {
				
				if ( this.filling_color != "#FFFFFF" ) {
					((dynamic)S).color = this.filling_color;
				} else {
					((dynamic)S).color = GlobalFuncs.AverageColor( GlobalFuncs.getFlatIcon( this, this.dir, 0 ), true, true );
				}
				((dynamic)S).name = "" + this.seed.seed_name + " smudge";
			}

			if ( this.seed.biolum != 0 && Lang13.Bool( this.seed.biolum_colour ) ) {
				new ByTable().Set( 1, 1 ).Set( "l_color", this.seed.biolum_colour ).Apply( Lang13.BindFunc( S, "set_light" ) );
			}
			return true;
		}

		// Function from file: grown.dm
		public void do_splat_effects( dynamic hit_atom = null ) {
			
			if ( this.seed.teleporting != 0 ) {
				this.splat_reagent_reaction( GlobalFuncs.get_turf( hit_atom ) );

				if ( this.do_fruit_teleport( hit_atom, Task13.User, this.potency ) ) {
					this.visible_message( "<span class='danger'>The " + this + " splatters, causing a distortion in space-time!</span>" );
				} else if ( this.splat_decal( GlobalFuncs.get_turf( hit_atom ) ) ) {
					this.visible_message( "<span class='notice'>The " + this.name + " has been squashed.</span>", "<span class='moderate'>You hear a smack.</span>" );
				}
				GlobalFuncs.qdel( this );
				return;
			}

			if ( this.seed.juicy != 0 ) {
				this.splat_decal( GlobalFuncs.get_turf( hit_atom ) );
				this.splat_reagent_reaction( GlobalFuncs.get_turf( hit_atom ) );
				this.visible_message( "<span class='notice'>The " + this.name + " has been squashed.</span>", "<span class='moderate'>You hear a smack.</span>" );
				GlobalFuncs.qdel( this );
				return;
			}
			return;
		}

		// Function from file: grown.dm
		public override dynamic throw_impact( dynamic hit_atom = null, dynamic speed = null, Mob user = null ) {
			base.throw_impact( (object)(hit_atom), (object)(speed), user );

			if ( !( this.seed != null ) || !( this != null ) ) {
				return null;
			}

			if ( hit_atom is Tile ) {
				this.do_splat_effects( hit_atom );
			}
			return null;
		}

	}

}