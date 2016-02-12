// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks : Obj_Item_Weapon_ReagentContainers_Food {

		public double? gulp_size = 5;
		public int duration = 13;
		public bool isGlass = false;
		public int molotov = 0;
		public bool lit = false;
		public int brightness_lit = 3;
		public int bottleheight = 23;
		public string smashtext = "bottle of ";
		public string smashname = "broken bottle";
		public bool viewcontents = true;
		public bool flammable = false;
		public bool flammin = false;
		public dynamic flammin_color = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 4352;
			this.possible_transfer_amounts = new ByTable(new object [] { 5, 10, 25 });
			this.icon = "icons/obj/drinks.dmi";
		}

		// Function from file: drinks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Drinks ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: drinks.dm
		public override dynamic process(  ) {
			dynamic loca = null;

			loca = GlobalFuncs.get_turf( this );

			if ( this.lit && Lang13.Bool( loca ) ) {
				((Tile)loca).hotspot_expose( 700, 1000, null, this.loc is Tile );
			}
			return null;
		}

		// Function from file: drinks.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Image Im = null;
			Ent_Static H = null;

			this.overlays.len = 0;

			if ( this.molotov == 1 ) {
				Im = new Image( "icons/obj/grenade.dmi", null, "molotov_rag" );
				Im.pixel_y += this.bottleheight - 23;
				this.overlays.Add( Im );
			}

			if ( this.molotov == 1 && this.lit ) {
				Im = new Image( "icons/obj/grenade.dmi", null, "molotov_fire" );
				Im.pixel_y += this.bottleheight - 23;
				this.overlays.Add( Im );
			} else {
				this.item_state = Lang13.Initial( this, "item_state" );
			}

			if ( this.loc is Mob_Living_Carbon_Human ) {
				H = this.loc;
				((dynamic)H).update_inv_belt();
			}
			return null;
		}

		// Function from file: drinks.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic C = null;

			
			if ( a is Obj_Item_Weapon_ReagentContainers_Glass_Rag && this.molotov == -1 ) {
				GlobalFuncs.to_chat( b, "<span  class='notice'>You stuff the " + a + " into the mouth of the " + this + ".</span>" );
				GlobalFuncs.qdel( a );
				a = null;
				this.molotov = 1;
				this.flags ^= 4096;
				this.name = "incendiary cocktail";
				this.smashtext = "";
				this.desc = "A rag stuffed into a bottle.";
				this.update_icon();
				this.slot_flags = 512;
			} else if ( Lang13.Bool( ((Obj)a).is_hot() ) ) {
				this.f_light( b, a );
				this.update_brightness( b );
			} else if ( a is Obj_Item_Device_Assembly_Igniter ) {
				C = a;
				C.activate();
				this.f_light( b, a );
				this.update_brightness( b );
				return null;
			}
			return null;
		}

		// Function from file: drinks.dm
		public override dynamic throw_impact( dynamic hit_atom = null, dynamic speed = null, Mob user = null ) {
			dynamic loca = null;
			Obj_Item_Weapon_BrokenBottle B = null;
			Icon Q = null;

			base.throw_impact( (object)(hit_atom), (object)(speed), user );

			if ( this.isGlass ) {
				this.isGlass = false;
				this.visible_message( "<span  class='warning'>The " + this.smashtext + this.name + " shatters!</span>", "<span  class='warning'>You hear a shatter!</span>" );
				GlobalFuncs.playsound( this, "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );

				if ( Lang13.Bool( this.reagents.total_volume ) ) {
					((Reagents)this.reagents).reaction( hit_atom, GlobalVars.TOUCH );
					Task13.Schedule( 5, (Task13.Closure)(() => {
						((Reagents)this.reagents).clear_reagents();
						return;
					}));
				}
				this.invisibility = 100;

				if ( this.molotov == 1 ) {
					
					if ( this.lit ) {
						new Obj_Effect_Decal_Cleanable_Ash( GlobalFuncs.get_turf( this ) );
						loca = GlobalFuncs.get_turf( this );

						if ( Lang13.Bool( loca ) ) {
							((Tile)loca).hotspot_expose( 700, 1000, null, this.loc is Tile );
						}
					} else {
						new Obj_Item_Weapon_ReagentContainers_Glass_Rag( GlobalFuncs.get_turf( this ) );
					}
				}
				B = new Obj_Item_Weapon_BrokenBottle( this.loc );
				B.force = this.force;
				B.name = this.smashname;
				B.icon_state = this.icon_state;

				if ( this is Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass ) {
					B.icon_state = "glass_empty";
				}

				if ( Rand13.PercentChance( 33 ) ) {
					GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), GlobalFuncs.get_turf( this ) );
				}
				Q = new Icon( "icons/obj/drinks.dmi", B.icon_state );
				Q.Blend( B.broken_outline, 3, Rand13.Int( 5 ), 1 );
				Q.SwapColor( "#ff00dcff", "#00000000" );
				B.icon = Q;
				this.transfer_fingerprints_to( B );
				Task13.Schedule( 50, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			return null;
		}

		// Function from file: drinks.dm
		public void update_brightness( dynamic user = null ) {
			
			if ( this.lit ) {
				this.set_light( this.brightness_lit );
			} else {
				this.set_light( 0 );
			}
			return;
		}

		// Function from file: drinks.dm
		[VerbInfo( name: "light" )]
		[VerbArg( 1, InputType.Mob )]
		[VerbArg( 2, InputType.Obj )]
		public void f_light( dynamic user = null, dynamic I = null ) {
			string flavor_text = null;

			flavor_text = new Txt( "<span  class='rose'>" ).item( user ).str( " lights " ).the( this.name ).item().str( " with " ).the( I ).item().str( ".</span>" ).ToString();

			if ( !this.lit && this.molotov == 1 ) {
				this.lit = true;
				this.visible_message( flavor_text );
				GlobalVars.processing_objects.Add( this );
				this.update_icon();
			}

			if ( !this.lit && this.flammable ) {
				this.lit = true;
				this.visible_message( flavor_text );
				this.flammable = false;
				this.name = "Flaming " + this.name;
				this.desc += " Damn that looks hot!";
				this.icon_state += "-flamin";
				this.update_icon();
			}
			return;
		}

		// Function from file: drinks.dm
		public void smash( dynamic M = null, dynamic user = null ) {
			Obj_Item_Weapon_BrokenBottle B = null;
			Icon I = null;

			
			if ( this.molotov == 1 ) {
				
				if ( this.lit ) {
					new Obj_Effect_Decal_Cleanable_Ash( GlobalFuncs.get_turf( this ) );
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Rag( GlobalFuncs.get_turf( this ) );
				}
			}
			new ByTable().Set( "force_drop", 1 ).Apply( Lang13.BindFunc( user, "drop_item" ) );
			B = new Obj_Item_Weapon_BrokenBottle( user.loc );
			B.icon_state = this.icon_state;
			B.name = this.smashname;

			if ( this is Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass ) {
				B.icon_state = "glass_empty";
			}

			if ( Rand13.PercentChance( 33 ) ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), GlobalFuncs.get_turf( M ) );
			}
			I = new Icon( "icons/obj/drinks.dmi", B.icon_state );
			I.Blend( B.broken_outline, 3, Rand13.Int( 5 ), 1 );
			I.SwapColor( "#ff00dcff", "#00000000" );
			B.icon = I;
			((Mob)user).put_in_active_hand( B );
			this.transfer_fingerprints_to( B );
			GlobalFuncs.playsound( this, "shatter", 70, 1 );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: drinks.dm
		public bool imbibe( dynamic user = null ) {
			dynamic H = null;

			GlobalFuncs.to_chat( user, new Txt( "<span  class='notice'>You swallow a gulp of " ).the( this ).item().str( "." ).item( ( this.lit ? " It's hot!" : "" ) ).str( "</span>" ).ToString() );
			GlobalFuncs.playsound( user.loc, "sound/items/drink.ogg", Rand13.Int( 10, 50 ), 1 );

			if ( this.lit ) {
				user.bodytemperature += 4.5;
				this.lit = false;
			}

			if ( user is Mob_Living_Silicon_Robot ) {
				((Reagents)this.reagents).remove_any( this.gulp_size );
				return true;
			}

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				
				if ( user is Mob_Living_Carbon_Human ) {
					H = user;

					if ( ( H.species.chem_flags & 1 ) != 0 ) {
						((Reagents)this.reagents).reaction( GlobalFuncs.get_turf( H ), GlobalVars.TOUCH );
						((Ent_Static)H).visible_message( "<span class='warning'>The contents in " + this + " fall through and splash onto the ground, what a mess!</span>" );
						return false;
					}
				}
				((Reagents)this.reagents).reaction( user, GlobalVars.INGEST );
				Task13.Schedule( 5, (Task13.Closure)(() => {
					((Reagents)this.reagents).trans_to( user, this.gulp_size );
					return;
				}));
			}
			this.update_brightness();
			return true;
		}

		// Function from file: drinks.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			
			if ( this.viewcontents ) {
				base.examine( (object)(user), size );
			} else {
				GlobalFuncs.to_chat( user, new Txt().icon( this ).str( " That's " ).a( this ).item().str( "." ).ToString() );
				GlobalFuncs.to_chat( user, this.desc );
				GlobalFuncs.to_chat( user, "<span class='info'>You can't quite make out its content!</span>" );
			}

			if ( !Lang13.Bool( this.reagents ) || this.reagents.total_volume == 0 ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( this ).item().str( " is empty!</span>" ).ToString() );
			} else if ( ( this.reagents.total_volume ??0) <= Convert.ToDouble( this.volume / 4 ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( this ).item().str( " is almost empty!</span>" ).ToString() );
			} else if ( ( this.reagents.total_volume ??0) <= Convert.ToDouble( this.volume * 0.66 ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( this ).item().str( " is about half full, or about half empty!</span>" ).ToString() );
			} else if ( ( this.reagents.total_volume ??0) <= Convert.ToDouble( this.volume * 081 ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( this ).item().str( " is almost full!</span>" ).ToString() );
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( this ).item().str( " is full!</span>" ).ToString() );
			}
			return null;
		}

		// Function from file: drinks.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			string refill_id = null;
			string refill_name = null;
			dynamic sent_amount = null;
			dynamic borg = null;
			double charge_amount = 0;

			
			if ( !( flag == true ) ) {
				return false;
			}

			if ( Lang13.Bool( this.transfer( A, user, GlobalVars.FALSE, GlobalVars.TRUE ) ) ) {
				return false;
			}
			refill_id = ((Reagents)this.reagents).get_master_reagent_id();
			refill_name = ((Reagents)this.reagents).get_master_reagent_name();
			sent_amount = this.transfer( A, user, GlobalVars.TRUE, GlobalVars.FALSE );

			if ( Convert.ToDouble( sent_amount ) > 0 && user is Mob_Living_Silicon_Robot ) {
				borg = user;

				if ( !( borg.module is Obj_Item_Weapon_RobotModule_Butler ) || !Lang13.Bool( borg.cell ) ) {
					return false;
				}
				charge_amount = Num13.MaxInt( 30, Convert.ToInt32( sent_amount * 4 ) );
				((Obj_Item_Weapon_Cell)borg.cell).use( charge_amount );
				GlobalFuncs.to_chat( user, "Now synthesizing " + sent_amount + " units of " + refill_name + "..." );
				Task13.Schedule( 300, (Task13.Closure)(() => {
					((Reagents)this.reagents).add_reagent( refill_id, sent_amount );
					GlobalFuncs.to_chat( user, "<span class='notice'>Cyborg " + this + " refilled with " + refill_name + " (" + sent_amount + " units).</span>" );
					return;
				}));
			}
			return false;
		}

		// Function from file: drinks.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic R = null;
			double? fillevel = null;
			string affecting = null;
			dynamic armor_block = null;
			dynamic armor_duration = null;
			dynamic H = null;
			bool headarmor = false;
			dynamic O = null;
			dynamic O2 = null;
			dynamic O3 = null;
			dynamic H2 = null;
			dynamic bro = null;
			string refill = null;

			R = this.reagents;
			fillevel = this.gulp_size;

			if ( user.a_intent == "hurt" && this.isGlass && this.molotov != 1 ) {
				
				if ( !Lang13.Bool( M ) ) {
					return null;
				}
				this.force = 15;
				affecting = ((dynamic)user.zone_sel).selecting;
				armor_block = 0;
				armor_duration = 0;

				if ( M is Mob_Living_Carbon_Human ) {
					H = M;
					headarmor = false;
					armor_block = ((Mob_Living)H).run_armor_check( affecting, "melee" );

					if ( H.head is Obj_Item_Clothing_Head && affecting == "head" ) {
						
						if ( Lang13.Bool( H.head.armor["melee"] ) ) {
							headarmor = Lang13.Bool( H.head.armor["melee"] );
						} else {
							headarmor = false;
						}
					} else {
						headarmor = false;
					}
					armor_duration = GlobalVars.duration - ( headarmor ?1:0) + Convert.ToDouble( this.force );
				} else {
					armor_block = ((Mob_Living)M).run_armor_check( affecting, "melee" );

					if ( affecting == "head" ) {
						armor_duration = this.force + 13;
					}
				}
				armor_duration /= 10;
				((Mob_Living)M).apply_damage( this.force, "brute", affecting, armor_block );

				if ( affecting == "head" && M is Mob_Living_Carbon ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, user ) )) {
						O = _a;
						

						if ( M != user ) {
							O.show_message( "<span class='danger'>" + M + " has been hit over the head with a " + this.smashtext + this.name + ", by " + user + "!</span>", 1 );
						} else {
							O.show_message( new Txt( "<span class='danger'>" ).item( M ).str( " hits " ).himself_herself_itself_themself().str( " with a " ).item( this.smashtext ).item( this.name ).str( " on the head!</span>" ).ToString(), 1 );
						}
					}

					if ( Lang13.Bool( armor_duration ) ) {
						((Mob_Living)M).apply_effect( Num13.MinInt( Convert.ToInt32( armor_duration ), 10 ), "weaken" );
					}
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, user ) )) {
						O2 = _b;
						

						if ( M != user ) {
							O2.show_message( "<span class='danger'>" + M + " has been attacked with a " + this.smashtext + this.name + ", by " + user + "!</span>", 1 );
						} else {
							O2.show_message( "<span class='danger'>" + M + " has attacked himself with a " + this.smashtext + this.name + "!</span>", 1 );
						}
					}
				}
				user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Has attacked " + M.name + " (" + M.ckey + ") with a bottle!</font>" );
				M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been smashed with a bottle by " + user.name + " (" + user.ckey + ")</font>" );
				GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") attacked " + M.name + " with a bottle. (" + M.ckey + ")</font>" ) ) );

				if ( !( user is Mob_Living_Carbon ) ) {
					M.LAssailant = null;
				} else {
					M.LAssailant = user;
				}

				if ( Lang13.Bool( this.reagents ) ) {
					
					foreach (dynamic _c in Lang13.Enumerate( Map13.FetchViewers( null, user ) )) {
						O3 = _c;
						
						O3.show_message( new Txt( "<span class='bnotice'>The contents of " ).the( this.smashtext ).item().item( this ).str( " splashes all over " ).item( M ).str( "!</span>" ).ToString(), 1 );
					}
					((Reagents)this.reagents).reaction( M, GlobalVars.TOUCH );
				}
				this.smash( M, user );
				return null;
			} else if ( !Lang13.Bool( this.is_open_container() ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You can't, " ).the( this ).item().str( " is closed.</span>" ).ToString() );
				return false;
			} else if ( !Lang13.Bool( R.total_volume ) || !Lang13.Bool( R ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).The( this ).item().str( " is empty.<span>" ).ToString() );
				return false;
			} else if ( M == user ) {
				this.imbibe( user );
				return false;
			} else if ( M is Mob_Living_Carbon_Human ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " attempts to feed " ).item( M ).str( " " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='danger'>You attempt to feed " ).item( M ).str( " " ).the( this ).item().str( ".</span>" ).ToString() );

				if ( !GlobalFuncs.do_mob( user, M ) ) {
					return null;
				}
				((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " feeds " ).item( M ).str( " " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='danger'>You feed " ).item( M ).str( " " ).the( this ).item().str( ".</span>" ).ToString() );
				M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been fed " + this.name + " by " + user.name + " (" + user.ckey + ") Reagents: " + this.reagentlist( this ) + "</font>" );
				user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Fed " + M.name + " by " + M.name + " (" + M.ckey + ") Reagents: " + this.reagentlist( this ) + "</font>" );
				GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") fed " + M.name + " (" + M.ckey + ") with " + this.name + " (INTENT: " + String13.ToUpper( user.a_intent ) + ")</font>" ) ) );

				if ( !( user is Mob_Living_Carbon ) ) {
					M.LAssailant = null;
				} else {
					M.LAssailant = user;
				}

				if ( Lang13.Bool( this.reagents.total_volume ) ) {
					
					if ( M is Mob_Living_Carbon_Human ) {
						H2 = M;

						if ( ( H2.species.chem_flags & 1 ) != 0 ) {
							((Reagents)this.reagents).reaction( GlobalFuncs.get_turf( H2 ), GlobalVars.TOUCH );
							((Ent_Static)H2).visible_message( "<span class='warning'>The contents in " + this + " fall through and splash onto the ground, what a mess!</span>" );
							return false;
						}
					}
					((Reagents)this.reagents).reaction( M, GlobalVars.INGEST );
					Task13.Schedule( 5, (Task13.Closure)(() => {
						((Reagents)this.reagents).trans_to( M, this.gulp_size );
						return;
					}));
				}

				if ( user is Mob_Living_Silicon_Robot ) {
					bro = user;
					((Obj_Item_Weapon_Cell)bro.cell).use( 30 );
					refill = ((Reagents)R).get_master_reagent_id();
					Task13.Schedule( 600, (Task13.Closure)(() => {
						((Reagents)R).add_reagent( refill, fillevel );
						return;
					}));
				}
				GlobalFuncs.playsound( M.loc, "sound/items/drink.ogg", Rand13.Int( 10, 50 ), 1 );
				return true;
			}
			return false;
		}

		// Function from file: drinks.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !Lang13.Bool( this.is_open_container() ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You can't, " ).the( this ).item().str( " is closed.</span>" ).ToString() );
				return 0;
			} else if ( !Lang13.Bool( this.reagents.total_volume ) || !( this != null ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).The( this ).item().str( " is empty.<span>" ).ToString() );
				return 0;
			} else {
				this.imbibe( user );
				return 0;
			}
			return null;
		}

		// Function from file: drinks.dm
		public override void on_reagent_change(  ) {
			
			if ( ( this.gulp_size ??0) < 5 ) {
				this.gulp_size = 5;
			} else {
				this.gulp_size = Num13.MaxInt( Num13.Floor( ( this.reagents.total_volume ??0) / 5 ), 5 );
			}

			if ( ((Reagents)this.reagents).has_reagent( "blackcolor" ) ) {
				this.viewcontents = false;
			} else {
				this.viewcontents = true;
			}
			return;
		}

	}

}