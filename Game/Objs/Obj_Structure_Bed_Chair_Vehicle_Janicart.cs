// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bed_Chair_Vehicle_Janicart : Obj_Structure_Bed_Chair_Vehicle {

		public int amount_per_transfer_from_this = 5;
		public dynamic mybag = null;
		public bool upgraded = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.nick = "pimpin' ride";
			this.keytype = typeof(Obj_Item_Key_Janicart);
			this.flags = 4096;
			this.icon_state = "pussywagon";
		}

		// Function from file: janicart.dm
		public Obj_Structure_Bed_Chair_Vehicle_Janicart ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 100 );
			return;
		}

		// Function from file: janicart.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static tile = null;
			dynamic A = null;
			dynamic cleaned_item = null;
			dynamic cleaned_human = null;

			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( this.upgraded ) {
				tile = this.loc;

				if ( tile is Tile ) {
					tile.clean_blood();

					foreach (dynamic _a in Lang13.Enumerate( tile )) {
						A = _a;
						

						if ( A is Obj_Effect ) {
							
							if ( A is Obj_Effect_Rune || A is Obj_Effect_Decal_Cleanable || A is Obj_Effect_Overlay ) {
								GlobalFuncs.qdel( A );
							}
						} else if ( A is Obj_Item ) {
							cleaned_item = A;
							((Ent_Static)cleaned_item).clean_blood();
						} else if ( A is Mob_Living_Carbon_Human ) {
							cleaned_human = A;

							if ( cleaned_human.lying == true ) {
								
								if ( Lang13.Bool( cleaned_human.head ) ) {
									((Ent_Static)cleaned_human.head).clean_blood();
									((Mob)cleaned_human).update_inv_head( false );
								}

								if ( Lang13.Bool( cleaned_human.wear_suit ) ) {
									((Ent_Static)cleaned_human.wear_suit).clean_blood();
									((Mob)cleaned_human).update_inv_wear_suit( false );
								} else if ( Lang13.Bool( cleaned_human.w_uniform ) ) {
									((Ent_Static)cleaned_human.w_uniform).clean_blood();
									((Mob)cleaned_human).update_inv_w_uniform( false );
								}

								if ( Lang13.Bool( cleaned_human.shoes ) ) {
									((Ent_Static)cleaned_human.shoes).clean_blood();
									((Mob)cleaned_human).update_inv_shoes( false );
								}
								((Ent_Static)cleaned_human).clean_blood();
								GlobalFuncs.to_chat( cleaned_human, "<span class='warning'>" + this + " cleans your face!</span>" );
							}
						}
					}
				}
			}
			return false;
		}

		// Function from file: janicart.dm
		public override void AltClick( Mob user = null ) {
			
			if ( Lang13.Bool( this.mybag ) ) {
				this.__CallVerb("Remove Trash Bag" );
				return;
			}
			base.AltClick( user );
			return;
		}

		// Function from file: janicart.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( this.occupant ) && this.occupant == a ) {
				return base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}

			if ( Lang13.Bool( this.mybag ) ) {
				this.__CallVerb("Remove Trash Bag" );
			} else {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: janicart.dm
		public override dynamic mop_act( Obj_Item_Weapon_Mop M = null, dynamic user = null ) {
			
			if ( M is Obj_Item_Weapon_Mop ) {
				
				if ( ( this.reagents.total_volume ??0) >= 2 ) {
					((Reagents)this.reagents).trans_to( M, 3 );
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You wet the mop in " ).the( this.nick ).item().str( ".</span>" ).ToString() );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );
				}

				if ( ( this.reagents.total_volume ??0) < 1 ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this.nick ).item().str( " is out of water!</span>" ).ToString() );
				}
			}
			return 1;
		}

		// Function from file: janicart.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_MechaParts_JanicartUpgrade && !this.upgraded && !this.destroyed ) {
				
				if ( Lang13.Bool( b.drop_item( a ) ) ) {
					GlobalFuncs.qdel( a );
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You upgrade " ).the( this.nick ).item().str( ".</span>" ).ToString() );
					this.upgraded = true;
					this.name = "upgraded " + this.name;
					this.icon_state = "pussywagon_upgraded";
				}
			} else if ( a is Obj_Item_Weapon_Storage_Bag_Trash ) {
				
				if ( Lang13.Bool( this.mybag ) ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='warning'>There's already a " ).item( a.name ).str( " on " ).the( this.nick ).item().str( "!</span>" ).ToString() );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You hook " ).the( a ).item().str( " onto " ).the( this.nick ).item().str( ".</span>" ).ToString() );
					this.mybag = a;
				}
			}
			return null;
		}

		// Function from file: janicart.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( GlobalFuncs.in_range( this, user ) && ((Reagents)this.reagents).has_reagent( "lube" ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'> Something is very off about this water.</span>" );
			}

			dynamic _a = this.health; // Was a switch-case, sorry for the mess.
			if ( 75<=_a&&_a<=99 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>It appears slightly dented.</span>" );
			} else if ( 40<=_a&&_a<=74 ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>It appears heavily dented.</span>" );
			} else if ( 1<=_a&&_a<=39 ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>It appears severely dented.</span>" );
			} else if ( Double.NegativeInfinity<=_a&&_a<=0 ) {
				GlobalFuncs.to_chat( user, "<span class='danger'>It appears completely unsalvageable.</span>" );
			}

			if ( Lang13.Bool( this.mybag ) ) {
				GlobalFuncs.to_chat( user, new Txt().A( this.mybag ).item().str( " is hanging on " ).the( this.nick ).item().str( "." ).ToString() );
			}
			return null;
		}

		// Function from file: janicart.dm
		[Verb]
		[VerbInfo( name: "Remove Trash Bag", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void remove_trashbag(  ) {
			
			if ( !Task13.User.incapacitated() && this.Adjacent( Task13.User ) && Lang13.Bool( Task13.User.dexterity_check() ) ) {
				((Ent_Dynamic)this.mybag).forceMove( GlobalFuncs.get_turf( Task13.User ) );
				Task13.User.put_in_hands( this.mybag );
				this.mybag = null;
			}
			return;
		}

	}

}