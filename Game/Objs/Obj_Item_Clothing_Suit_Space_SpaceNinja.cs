// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_SpaceNinja : Obj_Item_Clothing_Suit_Space {

		public dynamic affecting = null;
		public dynamic cell = null;
		public EffectSystem_SparkSpread spark_system = null;
		public ByTable reagent_list = new ByTable(new object [] { "omnizine", "salbutamol", "spaceacillin", "charcoal", "nutriment", "radium", "potass_iodide" });
		public ByTable stored_research = new ByTable();
		public dynamic t_disk = null;
		public Obj_Item_Weapon_Katana_Energy energyKatana = null;
		public dynamic n_hood = null;
		public dynamic n_shoes = null;
		public Obj_Item_Clothing_Gloves_SpaceNinja n_gloves = null;
		public bool s_initialized = false;
		public int s_coold = 0;
		public int s_cost = 5;
		public int s_acost = 25;
		public double s_delay = 40;
		public double? a_transfer = 20;
		public double? r_maxamount = 80;
		public bool spideros = false;
		public bool s_active = false;
		public bool s_busy = false;
		public int s_bombs = 10;
		public int a_boost = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "s-ninja_suit";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoBox), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Restraints_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_Internals), 
				typeof(Obj_Item_Weapon_StockParts_Cell)
			 });
			this.unacidable = true;
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 30 );
			this.strip_delay = 12;
			this.icon_state = "s-ninja";
		}

		// Function from file: suit.dm
		public Obj_Item_Clothing_Suit_Space_SpaceNinja ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic T = null;
			dynamic reagent_amount = null;
			dynamic reagent_id = null;
			dynamic reagent_id2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "init" ) );
			this.spark_system = new EffectSystem_SparkSpread();
			this.spark_system.set_up( 5, 0, this );
			this.spark_system.attach( this );
			this.stored_research = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Tech) ) - typeof(Tech) )) {
				T = _a;
				
				this.stored_research.Add( Lang13.Call( T, this ) );
			}
			reagent_amount = null;

			foreach (dynamic _b in Lang13.Enumerate( this.reagent_list )) {
				reagent_id = _b;
				
				reagent_amount += ( reagent_id == "radium" ? ( this.r_maxamount ??0) + this.a_boost * ( this.a_transfer ??0) : this.r_maxamount );
			}
			this.reagents = new Reagents( reagent_amount );
			this.reagents.my_atom = this;

			foreach (dynamic _c in Lang13.Enumerate( this.reagent_list )) {
				reagent_id2 = _c;
				
				if ( reagent_id2 == "radium" ) this.reagents.add_reagent( reagent_id2, ( this.r_maxamount ??0) + this.a_boost * ( this.a_transfer ??0) ); else this.reagents.add_reagent( reagent_id2, this.r_maxamount );
			}
			this.cell = new Obj_Item_Weapon_StockParts_Cell_High();
			this.cell.charge = 9000;
			this.cell.name = "black power cell";
			this.cell.icon_state = "bscell";
			return;
		}

		// Function from file: suit_attackby.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic total_reagent_transfer = null;
			dynamic reagent_id = null;
			dynamic R = null;
			double? amount_to_transfer = null;
			dynamic CELL = null;
			dynamic old_cell = null;
			dynamic TD = null;
			Tech current_data = null;

			
			if ( user == this.affecting ) {
				
				if ( A is Obj_Item_Weapon_ReagentContainers_Glass ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.reagent_list )) {
						reagent_id = _a;
						
						R = ((Reagents)A.reagents).has_reagent( reagent_id );

						if ( Lang13.Bool( R ) && ( this.reagents.get_reagent_amount( reagent_id ) ?1:0) < ( this.r_maxamount ??0) + ( reagent_id == "radium" ? this.a_boost * ( this.a_transfer ??0) : 0 ) && Convert.ToDouble( R.volume ) >= ( this.a_transfer ??0) ) {
							amount_to_transfer = Num13.MinInt( ((int)( ( this.r_maxamount ??0) + ( reagent_id == "radium" ? this.a_boost * ( this.a_transfer ??0) : 0 ) - ( this.reagents.get_reagent_amount( reagent_id ) ?1:0) )), ((int)( Num13.Floor( Convert.ToDouble( R.volume / this.a_transfer ) ) * ( this.a_transfer ??0) )) );
							R.volume -= amount_to_transfer;
							this.reagents.add_reagent( reagent_id, amount_to_transfer );
							total_reagent_transfer += amount_to_transfer;
							user.WriteMsg( "Added " + amount_to_transfer + " units of " + R.name + "." );
							((Reagents)A.reagents).update_total();
						}
					}
					user.WriteMsg( "Replenished a total of " + ( Lang13.Bool( total_reagent_transfer ) ? total_reagent_transfer : "zero" ) + " chemical units." );
					return null;
				} else if ( A is Obj_Item_Weapon_StockParts_Cell ) {
					CELL = A;

					if ( ( CELL.maxcharge ??0) > ( this.cell.maxcharge ??0) && this.n_gloves != null && this.n_gloves.candrain ) {
						user.WriteMsg( "<span class='notice'>Higher maximum capacity detected.\nUpgrading...</span>" );

						if ( this.n_gloves != null && this.n_gloves.candrain && GlobalFuncs.do_after( user, this.s_delay, null, this ) ) {
							user.drop_item();
							CELL.loc = this;
							CELL.charge = Num13.MinInt( Convert.ToInt32( CELL.charge + this.cell.charge ), ((int)( CELL.maxcharge ??0 )) );
							old_cell = this.cell;
							old_cell.charge = 0;
							((Mob)user).put_in_hands( old_cell );
							((Ent_Static)old_cell).add_fingerprint( user );
							((Obj_Item_Weapon_StockParts_Cell)old_cell).corrupt();
							old_cell.updateicon();
							this.cell = CELL;
							user.WriteMsg( "<span class='notice'>Upgrade complete. Maximum capacity: <b>" + Num13.Floor( ( this.cell.maxcharge ??0) / 100 ) + "</b>%</span>" );
						} else {
							user.WriteMsg( "<span class='danger'>Procedure interrupted. Protocol terminated.</span>" );
						}
					}
					return null;
				} else if ( A is Obj_Item_Weapon_Disk_TechDisk ) {
					TD = A;

					if ( Lang13.Bool( TD.stored ) ) {
						user.WriteMsg( "Research information detected, processing..." );

						if ( GlobalFuncs.do_after( user, this.s_delay, null, this ) ) {
							
							foreach (dynamic _b in Lang13.Enumerate( this.stored_research, typeof(Tech) )) {
								current_data = _b;
								

								if ( current_data.id == TD.stored.id ) {
									
									if ( ( current_data.level ?1:0) < Convert.ToDouble( TD.stored.level ) ) {
										current_data.level = Lang13.Bool( TD.stored.level );
									}
									break;
								}
							}
							TD.stored = null;
							user.WriteMsg( "<span class='notice'>Data analyzed and updated. Disk erased.</span>" );
						} else {
							user.WriteMsg( "<span class='userdanger'>ERROR</span>: Procedure interrupted. Process terminated." );
						}
					} else {
						A.loc = this;
						this.t_disk = A;
						user.WriteMsg( new Txt( "<span class='notice'>You slot " ).the( A ).item().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
					}
					return null;
				}
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: suit.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.s_initialized ) {
				
				if ( user == this.affecting ) {
					user.WriteMsg( "All systems operational. Current energy capacity: <B>" + this.cell.charge + "</B>." );
					user.WriteMsg( "The CLOAK-tech device is <B>" + ( this.s_active ? "active" : "inactive" ) + "</B>." );
					user.WriteMsg( new Txt( "There are <B>" ).item( this.s_bombs ).str( "</B> smoke bomb" ).s().str( " remaining." ).ToString() );
					user.WriteMsg( new Txt( "There are <B>" ).item( this.a_boost ).str( "</B> adrenaline booster" ).s().str( " remaining." ).ToString() );
				}
			}
			return 0;
		}

		// Function from file: ninja_teleporting.dm
		[VerbInfo( name: "Phase Shift (20E)", desc: "Utilizes the internal VOID-shift device to rapidly transit to a destination in view.", access: VerbAccess.InUserContents, range: 127 )]
		[VerbArg( 1, InputType.Tile, VerbArgFilter.InViewExcludeThis )]
		public void ninjashift( Ent_Static T = null ) {
			dynamic H = null;
			dynamic mobloc = null;

			
			if ( !( this.ninjacost( 200, 1 ) != 0 ) ) {
				H = this.affecting;
				mobloc = GlobalFuncs.get_turf( H.loc );

				if ( !T.density && mobloc is Tile ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						GlobalFuncs.playsound( H.loc, "sound/effects/sparks4.ogg", 50, 1 );
						GlobalFuncs.anim( mobloc, this, "icons/mob/mob.dmi", null, "phaseout", null, Convert.ToInt32( H.dir ) );
						return;
					}));
					this.handle_teleport_grab( T, H );
					H.loc = T;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.spark_system.start();
						GlobalFuncs.playsound( H.loc, "sound/effects/phasein.ogg", 25, 1 );
						GlobalFuncs.playsound( H.loc, "sound/effects/sparks2.ogg", 50, 1 );
						GlobalFuncs.anim( H.loc, H, "icons/mob/mob.dmi", null, "phasein", null, Convert.ToInt32( H.dir ) );
						return;
					}));
					Task13.Schedule( 0, (Task13.Closure)(() => {
						((dynamic)T).phase_damage_creatures( 20, H );
						return;
					}));
					this.s_coold = 1;
				} else {
					H.WriteMsg( "<span class='danger'>You cannot teleport into solid walls or from solid matter</span>" );
				}
			}
			return;
		}

		// Function from file: ninja_teleporting.dm
		[VerbInfo( name: "Phase Jaunt (10E)", desc: "Utilizes the internal VOID-shift device to rapidly transit in direction facing.", group: "Ninja Ability" )]
		public void ninjajaunt(  ) {
			dynamic H = null;
			dynamic destination = null;
			dynamic mobloc = null;

			
			if ( !( this.ninjacost( 100, 1 ) != 0 ) ) {
				H = this.affecting;
				destination = GlobalFuncs.get_teleport_loc( H.loc, H, 9, true, 3, 1, false, true );
				mobloc = GlobalFuncs.get_turf( H.loc );

				if ( Lang13.Bool( destination ) && mobloc is Tile ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						GlobalFuncs.playsound( H.loc, "sparks", 50, 1 );
						GlobalFuncs.anim( mobloc, this, "icons/mob/mob.dmi", null, "phaseout", null, Convert.ToInt32( H.dir ) );
						return;
					}));
					this.handle_teleport_grab( destination, H );
					H.loc = destination;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.spark_system.start();
						GlobalFuncs.playsound( H.loc, "sound/effects/phasein.ogg", 25, 1 );
						GlobalFuncs.playsound( H.loc, "sparks", 50, 1 );
						GlobalFuncs.anim( H.loc, H, "icons/mob/mob.dmi", null, "phasein", null, Convert.ToInt32( H.dir ) );
						return;
					}));
					Task13.Schedule( 0, (Task13.Closure)(() => {
						((Tile)destination).phase_damage_creatures( 20, H );
						return;
					}));
					this.s_coold = 1;
				} else {
					H.WriteMsg( "<span class='danger'>The VOID-shift device is malfunctioning, <B>teleportation failed</B>.</span>" );
				}
			}
			return;
		}

		// Function from file: ninja_teleporting.dm
		public void handle_teleport_grab( dynamic T = null, dynamic H = null ) {
			Ent_Dynamic victim = null;

			
			if ( Lang13.Bool( H.pulling ) && H.pulling is Mob_Living ) {
				victim = H.pulling;

				if ( !Lang13.Bool( victim.anchored ) ) {
					victim.forceMove( Map13.GetTile( Convert.ToInt32( T.x + Rand13.Int( -1, 1 ) ), Convert.ToInt32( T.y + Rand13.Int( -1, 1 ) ), Convert.ToInt32( T.z ) ) );
				}
			}
			return;
		}

		// Function from file: ninja_sword_recall.dm
		[VerbInfo( name: "Recall Energy Katana (Variable Cost)", desc: "Teleports the Energy Katana linked to this suit to it's wearer, cost based on distance.", group: "Ninja Ability" )]
		public void ninja_sword_recall(  ) {
			dynamic H = null;
			int? cost = null;
			bool inview = false;
			int distance = 0;
			Ent_Static C = null;

			H = this.affecting;
			cost = 0;
			inview = true;

			if ( !( this.energyKatana != null ) ) {
				H.WriteMsg( "<span class='warning'>Could not locate Energy Katana!</span>" );
				return;
			}

			if ( Lang13.Bool( H.Contains( this.energyKatana ) ) ) {
				return;
			}
			distance = Map13.GetDistance( H, this.energyKatana );

			if ( !Map13.FetchInView( null, H ).Contains( this.energyKatana ) ) {
				cost = distance;
				inview = false;
			}

			if ( !( this.ninjacost( cost ) != 0 ) ) {
				
				if ( this.energyKatana.loc is Mob_Living_Carbon ) {
					C = this.energyKatana.loc;
					((Mob)C).unEquip( this.energyKatana );

					if ( Lang13.Bool( ((dynamic)C).stomach_contents.Contains( this.energyKatana ) ) ) {
						((dynamic)C).stomach_contents -= this.energyKatana;
					}

					if ( Lang13.Bool( ((dynamic)C).internal_organs.Contains( this.energyKatana ) ) ) {
						((dynamic)C).internal_organs -= this.energyKatana;
					}
				}
				this.energyKatana.loc = GlobalFuncs.get_turf( this.energyKatana );

				if ( inview ) {
					this.energyKatana.spark_system.start();
					GlobalFuncs.playsound( H, "sparks", 50, 1 );
					((Ent_Static)H).visible_message( new Txt( "<span class='danger'>" ).the( this.energyKatana ).item().str( " flies towards " ).item( H ).str( "!</span>" ).ToString(), new Txt( "<span class='warning'>You hold out your hand and " ).the( this.energyKatana ).item().str( " flies towards you!</span>" ).ToString() );
					this.energyKatana.throw_at( H, distance + 1, this.energyKatana.throw_speed, H );
				} else {
					this.energyKatana.returnToOwner( H, true );
				}
			}
			return;
		}

		// Function from file: ninja_stealth.dm
		[VerbInfo( name: "Toggle Stealth", desc: "Utilize the internal CLOAK-tech device to activate or deactivate stealth-camo.", group: "Ninja Equip" )]
		public void stealth(  ) {
			
			if ( !this.s_busy ) {
				this.toggle_stealth();
			} else {
				this.affecting.WriteMsg( "<span class='danger'>Stealth does not appear to work!</span>" );
			}
			return;
		}

		// Function from file: ninja_stealth.dm
		public bool cancel_stealth(  ) {
			dynamic U = null;

			U = this.affecting;

			if ( !Lang13.Bool( U ) ) {
				return false;
			}

			if ( this.s_active ) {
				this.s_active = !this.s_active;
				Icon13.Animate( new ByTable().Set( 1, U ).Set( "alpha", 255 ).Set( "time", 15 ) );
				((Ent_Static)U).visible_message( "<span class='warning'>" + U.name + " appears from thin air!</span>", "<span class='notice'>You are now visible.</span>" );
				return true;
			}
			return false;
		}

		// Function from file: ninja_stealth.dm
		public void toggle_stealth(  ) {
			dynamic U = null;

			U = this.affecting;

			if ( !Lang13.Bool( U ) ) {
				return;
			}

			if ( this.s_active ) {
				this.cancel_stealth();
			} else {
				
				if ( Convert.ToDouble( this.cell.charge ) <= 0 ) {
					U.WriteMsg( "<span class='warning'>You don't have enough power to enable Stealth!</span>" );
					return;
				}
				this.s_active = !this.s_active;
				Icon13.Animate( new ByTable().Set( 1, U ).Set( "alpha", 0 ).Set( "time", 15 ) );
				((Ent_Static)U).visible_message( "<span class='warning'>" + U.name + " vanishes into thin air!</span>", "<span class='notice'>You are now invisible to normal detection.</span>" );
			}
			return;
		}

		// Function from file: ninja_stars.dm
		[VerbInfo( name: "Create Throwing Stars (1E)", desc: "Creates some throwing stars", group: "Ninja Ability" )]
		public void ninjastar(  ) {
			dynamic H = null;
			int slot = 0;

			
			if ( !( this.ninjacost( 10 ) != 0 ) ) {
				H = this.affecting;
				slot = ( H.hand ? 4 : 5 );

				if ( Lang13.Bool( ((Mob)H).equip_to_slot_or_del( new Obj_Item_Weapon_ThrowingStar_Ninja( H ), slot ) ) ) {
					H.WriteMsg( "<span class='notice'>A throwing star has been created in your hand!</span>" );
				}
				((Mob_Living_Carbon)H).throw_mode_on();
			}
			return;
		}

		// Function from file: tgstation.dme
		[VerbInfo( name: "Smoke Bomb", desc: "Blind your enemies momentarily with a well-placed smoke bomb.", group: "Ninja Ability" )]
		public void ninjasmoke(  ) {
			dynamic H = null;
			EffectSystem_SmokeSpread_Bad smoke = null;

			
			if ( !( this.ninjacost( 0, 2 ) != 0 ) ) {
				H = this.affecting;
				smoke = new EffectSystem_SmokeSpread_Bad();
				smoke.set_up( 4, H.loc );
				smoke.start();
				GlobalFuncs.playsound( H.loc, "sound/effects/bamf.ogg", 50, 2 );
				this.s_bombs--;
				H.WriteMsg( "<span class='notice'>There are <B>" + this.s_bombs + "</B> smoke bombs remaining.</span>" );
				this.s_coold = 1;
			}
			return;
		}

		// Function from file: tgstation.dme
		[VerbInfo( name: "Energy Net (20E)", desc: "Captures a fallen opponent in a net of energy. Will teleport them to a holding facility after 30 seconds.", access: VerbAccess.InUserContents, range: 127 )]
		[VerbArg( 1, InputType.Mob, VerbArgFilter.InViewExcludeThis )]
		public void ninjanet( Ent_Static C = null ) {
			dynamic H = null;
			dynamic T = null;
			Obj_Effect_EnergyNet E = null;

			
			if ( !( this.ninjacost( 200, 1 ) != 0 ) && C is Mob_Living_Carbon ) {
				H = this.affecting;

				if ( Lang13.Bool( ((dynamic)C).client ) ) {
					
					if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_EnergyNet), C.loc ) ) ) {
						
						foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.getline( H.loc, C.loc ) )) {
							T = _a;
							

							if ( T.density ) {
								H.WriteMsg( "<span class='warning'>You may not use an energy net through solid obstacles!</span>" );
								return;
							}
						}
						Task13.Schedule( 0, (Task13.Closure)(() => {
							((Ent_Static)H).Beam( C, "n_beam", null, 15 );
							return;
						}));
						((Ent_Dynamic)H).say( "Get over here!" );
						E = new Obj_Effect_EnergyNet( C.loc );
						E.layer = C.layer + 1;
						((Ent_Static)H).visible_message( "<span class='danger'>" + H + " caught " + C + " with an energy net!</span>", "<span class='notice'>You caught " + C + " with an energy net!</span>" );
						E.affecting = C;
						E.master = H;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							E.process( C );
							return;
						}));
					} else {
						H.WriteMsg( "<span class='warning'>They are already trapped inside an energy net!</span>" );
					}
				} else {
					H.WriteMsg( "<span class='warning'>They will bring no honor to your Clan!</span>" );
				}
			}
			return;
		}

		// Function from file: tgstation.dme
		[VerbInfo( name: "EM Burst (25E)", desc: "Disable any nearby technology with a electro-magnetic pulse.", group: "Ninja Ability" )]
		public void ninjapulse(  ) {
			dynamic H = null;

			
			if ( !( this.ninjacost( 250, 1 ) != 0 ) ) {
				H = this.affecting;
				GlobalFuncs.playsound( H.loc, "sound/effects/EMPulse.ogg", 60, 2 );
				GlobalFuncs.empulse( H, 4, 6 );
				this.s_coold = 2;
			}
			return;
		}

		// Function from file: ninja_cost_check.dm
		public int ninjacost( int? cost = null, int? specificCheck = null ) {
			cost = cost ?? 0;
			specificCheck = specificCheck ?? 0;

			dynamic H = null;
			int actualCost = 0;

			H = this.affecting;

			if ( ( Lang13.Bool( H.stat ) || H.incorporeal_move != 0 ) && specificCheck != 3 ) {
				H.WriteMsg( "<span class='danger'>You must be conscious and solid to do this.</span>" );
				return 1;
			}
			actualCost = ( cost ??0) * 10;

			if ( Lang13.Bool( cost ) && Convert.ToDouble( this.cell.charge ) < actualCost ) {
				H.WriteMsg( "<span class='danger'>Not enough energy.</span>" );
				return 1;
			} else {
				this.cell.charge -= actualCost;
			}

			switch ((int?)( specificCheck )) {
				case 1:
					this.cancel_stealth();
					break;
				case 2:
					
					if ( !( this.s_bombs != 0 ) ) {
						H.WriteMsg( "<span class='danger'>There are no more smoke bombs remaining.</span>" );
						return 1;
					}
					break;
				case 3:
					
					if ( !( this.a_boost != 0 ) ) {
						H.WriteMsg( "<span class='danger'>You do not have any more adrenaline boosters.</span>" );
						return 1;
					}
					break;
			}
			return this.s_coold;
		}

		// Function from file: tgstation.dme
		[VerbInfo( name: "Adrenaline Boost", desc: "Inject a secret chemical that will counteract all movement-impairing effect.", group: "Ninja Ability" )]
		public void ninjaboost(  ) {
			dynamic H = null;
			double? fraction = null;

			
			if ( !( this.ninjacost( 0, 3 ) != 0 ) ) {
				H = this.affecting;
				((Mob)H).SetParalysis( 0 );
				((Mob)H).SetStunned( 0 );
				((Mob)H).SetWeakened( 0 );
				Task13.Schedule( 30, (Task13.Closure)(() => {
					((Ent_Dynamic)H).say( Rand13.Pick(new object [] { "A CORNERED FOX IS MORE DANGEROUS THAN A JACKAL!", "HURT ME MOOORRREEE!", "IMPRESSIVE!" }) );
					return;
				}));
				Task13.Schedule( 70, (Task13.Closure)(() => {
					
					if ( Lang13.Bool( this.reagents.total_volume ) ) {
						fraction = Num13.MinInt( ((int)( ( this.a_transfer ??0) / ( this.reagents.total_volume ??0) )), 1 );
						this.reagents.reaction( H, GlobalVars.INJECT, fraction );
					}
					this.reagents.trans_id_to( H, "radium", this.a_transfer );
					H.WriteMsg( "<span class='danger'>You are beginning to feel the after-effect of the injection.</span>" );
					return;
				}));
				this.a_boost--;
				this.s_coold = 3;
			}
			return;
		}

		// Function from file: suit_verbs_handlers.dm
		public void remove_ninja_verbs(  ) {
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjashift" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjajaunt" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjasmoke" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjaboost" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjapulse" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjastar" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjanet" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninja_sword_recall" ) );
			return;
		}

		// Function from file: suit_verbs_handlers.dm
		public void grant_ninja_verbs(  ) {
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjashift" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjajaunt" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjasmoke" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjaboost" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjapulse" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjastar" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninjanet" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "ninja_sword_recall" ) );
			this.s_initialized = true;
			this.slowdown = 0;
			return;
		}

		// Function from file: suit_verbs_handlers.dm
		public void remove_equip_verbs(  ) {
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "init" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "deinit" ) );
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "stealth" ) );

			if ( this.n_gloves != null ) {
				this.n_gloves.verbs.Remove( typeof(Obj_Item_Clothing_Gloves_SpaceNinja).GetMethod( "toggled" ) );
			}
			this.s_initialized = false;
			return;
		}

		// Function from file: suit_verbs_handlers.dm
		public void grant_equip_verbs(  ) {
			this.verbs.Remove( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "init" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "deinit" ) );
			this.verbs.Add( typeof(Obj_Item_Clothing_Suit_Space_SpaceNinja).GetMethod( "stealth" ) );
			this.n_gloves.verbs.Add( typeof(Obj_Item_Clothing_Gloves_SpaceNinja).GetMethod( "toggled" ) );
			this.s_initialized = true;
			return;
		}

		// Function from file: suit_process.dm
		public void ntick( dynamic U = null ) {
			U = U ?? this.affecting;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				while (this.s_initialized) {
					
					if ( !Lang13.Bool( this.affecting ) ) {
						this.terminate();
					} else if ( Convert.ToDouble( this.cell.charge ) > 0 ) {
						
						if ( this.s_coold != 0 ) {
							this.s_coold--;
						}
						this.cell.charge -= this.s_cost;

						if ( this.s_active ) {
							this.cell.charge -= this.s_acost;
						}
					} else {
						this.cell.charge = 0;
						this.cancel_stealth();
					}
					Task13.Sleep( 10 );
				}
				return;
			}));
			return;
		}

		// Function from file: tgstation.dme
		public void deinitialize( double? delay = null ) {
			delay = delay ?? this.s_delay;

			dynamic U = null;
			int? i = null;

			
			if ( this.affecting == this.loc && !this.s_busy ) {
				U = this.affecting;

				if ( !this.s_initialized ) {
					U.WriteMsg( "<span class='danger'>The suit is not initialized.</span> Please report this bug." );
					return;
				}

				if ( Interface13.Alert( "Are you certain you wish to remove the suit? This will take time and remove all abilities.", null, "Yes", "No" ) == "No" ) {
					return;
				}

				if ( this.s_busy ) {
					U.WriteMsg( "<span class='userdanger'>ERROR</span>: You cannot use this function at this time." );
					return;
				}
				this.s_busy = true;
				i = null;
				i = 0;

				while (( i ??0) < 7) {
					
					switch ((int?)( i )) {
						case 0:
							U.WriteMsg( "<span class='notice'>Now de-initializing...</span>" );
							this.spideros = false;
							break;
						case 1:
							U.WriteMsg( "<span class='notice'>Logging off, " + U.real_name + ". Shutting down <B>SpiderOS</B>.</span>" );
							this.remove_ninja_verbs();
							break;
						case 2:
							U.WriteMsg( "<span class='notice'>Primary system status: <B>OFFLINE</B>.\nBackup system status: <B>OFFLINE</B>.</span>" );
							break;
						case 3:
							U.WriteMsg( "<span class='notice'>VOID-shift device status: <B>OFFLINE</B>.\nCLOAK-tech device status: <B>OFFLINE</B>.</span>" );
							this.cancel_stealth();
							break;
						case 4:
							U.WriteMsg( "<span class='notice'>Disconnecting neural-net interface...</span>ÿ <B>Success</B><span class='notice'>.</span>" );
							break;
						case 5:
							U.WriteMsg( "<span class='notice'>Disengaging neural-net interface...</span>ÿ <B>Success</B><span class='notice'>.</span>" );
							break;
						case 6:
							U.WriteMsg( "<span class='notice'>Unsecuring external locking mechanism...\nNeural-net abolished.\nOperation status: <B>FINISHED</B>.</span>" );
							this.remove_equip_verbs();
							this.unlock_suit();
							((Mob)U).regenerate_icons();
							break;
					}
					Task13.Sleep( ((int)( delay ??0 )) );
					i++;
				}
				this.s_busy = false;
			}
			return;
		}

		// Function from file: suit_initialisation.dm
		public void ninitialize( double? delay = null, dynamic U = null ) {
			delay = delay ?? this.s_delay;
			U = U ?? this.loc;

			int? i = null;

			
			if ( Lang13.Bool( U.mind ) && U.mind.assigned_role == U.mind.special_role && !this.s_initialized && !this.s_busy ) {
				this.s_busy = true;
				i = null;

				while (( i ??0) < 7) {
					
					switch ((int?)( i )) {
						case 0:
							U.WriteMsg( "<span class='notice'>Now initializing...</span>" );
							break;
						case 1:
							
							if ( !this.lock_suit( U ) ) {
								break;
							}
							U.WriteMsg( "<span class='notice'>Securing external locking mechanism...\nNeural-net established.</span>" );
							break;
						case 2:
							U.WriteMsg( "<span class='notice'>Extending neural-net interface...\nNow monitoring brain wave pattern...</span>" );
							break;
						case 3:
							
							if ( Convert.ToInt32( U.stat ) == 2 || Convert.ToDouble( U.health ) <= 0 ) {
								U.WriteMsg( "<span class='danger'><B>FÃÂAL Ã¯Â¿Â½RrÃ¯Â¿Â½R</B>: 344--93#Ã¯Â¿Â½&&21 BRÃ¯Â¿Â½Ã¯Â¿Â½N |/|/aVÃ¯Â¿Â½ PATT$RN <B>RED</B>\nA-A-aBÃ¯Â¿Â½rTÃ¯Â¿Â½NG...</span>" );
								this.unlock_suit();
								break;
							}
							this.lock_suit( U, true );
							((Mob)U).regenerate_icons();
							U.WriteMsg( "<span class='notice'>Linking neural-net interface...\nPattern</span>ÿ <B>GREEN</B><span class='notice'>, continuing operation.</span>" );
							break;
						case 4:
							U.WriteMsg( "<span class='notice'>VOID-shift device status: <B>ONLINE</B>.\nCLOAK-tech device status: <B>ONLINE</B>.</span>" );
							break;
						case 5:
							U.WriteMsg( "<span class='notice'>Primary system status: <B>ONLINE</B>.\nBackup system status: <B>ONLINE</B>.\nCurrent energy capacity: <B>" + this.cell.charge + "</B>.</span>" );
							break;
						case 6:
							U.WriteMsg( "<span class='notice'>All systems operational. Welcome to <B>SpiderOS</B>, " + U.real_name + ".</span>" );
							this.grant_ninja_verbs();
							this.grant_equip_verbs();
							this.ntick();
							break;
					}
					Task13.Sleep( ((int)( delay ??0 )) );
					i++;
				}
				this.s_busy = false;
			} else if ( !Lang13.Bool( U.mind ) || U.mind.assigned_role != U.mind.special_role ) {
				U.WriteMsg( "You do not understand how this suit functions. Where the heck did it even come from?" );
			} else if ( this.s_initialized ) {
				U.WriteMsg( "<span class='danger'>The suit is already functioning.</span> Please report this bug." );
			} else {
				U.WriteMsg( "<span class='userdanger'>ERROR</span>: You cannot use this function at this time." );
			}
			return;
		}

		// Function from file: suit_initialisation.dm
		[VerbInfo( name: "De-Initialize Suit", desc: "Begins procedure to remove the suit.", group: "Ninja Equip" )]
		public void deinit(  ) {
			
			if ( !this.s_busy ) {
				this.deinitialize();
			} else {
				this.affecting.WriteMsg( "<span class='danger'>The function did not trigger!</span>" );
			}
			return;
		}

		// Function from file: suit_initialisation.dm
		[VerbInfo( name: "Initialize Suit", desc: "Initializes the suit for field operation.", group: "Ninja Equip" )]
		public void init(  ) {
			this.ninitialize();
			return;
		}

		// Function from file: suit.dm
		public void unlock_suit(  ) {
			this.affecting = null;
			this.flags &= 65533;
			this.slowdown = 1;
			this.icon_state = "s-ninja";

			if ( Lang13.Bool( this.n_hood ) ) {
				this.n_hood.flags &= 65533;
			}

			if ( Lang13.Bool( this.n_shoes ) ) {
				this.n_shoes.flags &= 65533;
				this.n_shoes.slowdown++;
			}

			if ( this.n_gloves != null ) {
				this.n_gloves.icon_state = "s-ninja";
				this.n_gloves.item_state = "s-ninja";
				this.n_gloves.flags &= 65533;
				this.n_gloves.candrain = false;
				this.n_gloves.draining = false;
			}
			return;
		}

		// Function from file: suit.dm
		public bool lock_suit( dynamic H = null, bool? checkIcons = null ) {
			checkIcons = checkIcons ?? false;

			
			if ( !( H is Mob_Living_Carbon_Human ) ) {
				return false;
			}

			if ( checkIcons == true ) {
				this.icon_state = ( H.gender == GlobalVars.FEMALE ? "s-ninjanf" : "s-ninjan" );
				H.gloves.icon_state = "s-ninjan";
				H.gloves.item_state = "s-ninjan";
			} else {
				
				if ( H.mind.special_role != "Space Ninja" ) {
					H.WriteMsg( "ÿ<B>fÃTaL ÃÃRRoR</B>: 382200-*#00CÃDE <B>RED</B>\nUNAUÂHORIZED USÃ DETÃCÂÂÂeD\nCoMMÃNCING SUB-R0UÂIN3 13...\nTÃRMInATING U-U-USÃR..." );
					((Mob)H).gib();
					return false;
				}

				if ( !( H.head is Obj_Item_Clothing_Head_Helmet_Space_SpaceNinja ) ) {
					H.WriteMsg( "<span class='userdanger'>ERROR</span>: 100113 UNABLE TO LOCATE HEAD GEAR\nABORTING..." );
					return false;
				}

				if ( !( H.shoes is Obj_Item_Clothing_Shoes_SpaceNinja ) ) {
					H.WriteMsg( "<span class='userdanger'>ERROR</span>: 122011 UNABLE TO LOCATE FOOT GEAR\nABORTING..." );
					return false;
				}

				if ( !( H.gloves is Obj_Item_Clothing_Gloves_SpaceNinja ) ) {
					H.WriteMsg( "<span class='userdanger'>ERROR</span>: 110223 UNABLE TO LOCATE HAND GEAR\nABORTING..." );
					return false;
				}
				this.affecting = H;
				this.flags |= 2;
				this.slowdown = 0;
				this.n_hood = H.head;
				this.n_hood.flags |= 2;
				this.n_shoes = H.shoes;
				this.n_shoes.flags |= 2;
				this.n_shoes.slowdown--;
				this.n_gloves = H.gloves;
				this.n_gloves.flags |= 2;
			}
			return true;
		}

		// Function from file: suit.dm
		public void randomize_param(  ) {
			this.s_cost = Rand13.Int( 1, 20 );
			this.s_acost = Rand13.Int( 20, 100 );
			this.s_delay = Rand13.Int( 10, 100 );
			this.s_bombs = Rand13.Int( 5, 20 );
			this.a_boost = Rand13.Int( 1, 7 );
			return;
		}

		// Function from file: suit.dm
		public void terminate(  ) {
			GlobalFuncs.qdel( this.n_hood );
			GlobalFuncs.qdel( this.n_gloves );
			GlobalFuncs.qdel( this.n_shoes );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: suit.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.affecting ) ) {
				Interface13.Browse( this.affecting, null, "window=hack spideros" );
			}
			return base.Destroy();
		}

	}

}