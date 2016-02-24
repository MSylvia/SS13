// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Toilet : Obj_Structure {

		public int open = 0;
		public bool cistern = false;
		public double w_items = 0;
		public Ent_Static swirlie = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/watercloset.dmi";
			this.icon_state = "toilet00";
		}

		// Function from file: watercloset.dm
		public Obj_Structure_Toilet ( dynamic loc = null ) : base( (object)(loc) ) {
			this.open = Num13.Floor( Rand13.Int( 0, 1 ) );
			this.update_icon();
			return;
		}

		// Function from file: watercloset.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic RG = null;
			dynamic G = null;
			Ent_Static GM = null;
			Ent_Static C = null;

			
			if ( A is Obj_Item_Weapon_Crowbar ) {
				user.WriteMsg( "<span class='notice'>You start to " + ( this.cistern ? "replace the lid on the cistern" : "lift the lid off the cistern" ) + "...</span>" );
				GlobalFuncs.playsound( this.loc, "sound/effects/stonedoor_openclose.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( user, 30 / A.toolspeed, null, this ) ) {
					((Ent_Static)user).visible_message( "" + user + " " + ( this.cistern ? "replaces the lid on the cistern" : "lifts the lid off the cistern" ) + "!", "<span class='notice'>You " + ( this.cistern ? "replace the lid on the cistern" : "lift the lid off the cistern" ) + "!</span>", "<span class='italics'>You hear grinding porcelain.</span>" );
					this.cistern = !this.cistern;
					this.update_icon();
					return null;
				}
			}

			if ( A is Obj_Item_Weapon_ReagentContainers ) {
				
				if ( !( this.open != 0 ) ) {
					return null;
				}
				RG = A;
				RG.reagents.add_reagent( "water", Num13.MinInt( Convert.ToInt32( RG.volume - RG.reagents.total_volume ), Convert.ToInt32( RG.amount_per_transfer_from_this ) ) );
				user.WriteMsg( "<span class='notice'>You fill " + RG + " from " + this + ". Gross.</span>" );
				return null;
			}

			if ( A is Obj_Item_Weapon_Grab ) {
				((Mob)user).changeNext_move( 8 );
				G = A;

				if ( !((Obj_Item_Weapon_Grab)G).confirm() ) {
					return null;
				}

				if ( G.affecting is Mob_Living ) {
					GM = G.affecting;

					if ( Convert.ToDouble( G.state ) >= 2 ) {
						
						if ( GM.loc != GlobalFuncs.get_turf( this ) ) {
							user.WriteMsg( "<span class='warning'>" + GM + " needs to be on " + this + "!</span>" );
							return null;
						}

						if ( !( this.swirlie != null ) ) {
							
							if ( this.open != 0 ) {
								GM.visible_message( "<span class='danger'>" + user + " starts to give " + GM + " a swirlie!</span>", "<span class='userdanger'>" + user + " starts to give " + GM + " a swirlie...</span>" );
								this.swirlie = GM;

								if ( GlobalFuncs.do_after( user, 30, false, this ) ) {
									GM.visible_message( "<span class='danger'>" + user + " gives " + GM + " a swirlie!</span>", "<span class='userdanger'>" + user + " gives " + GM + " a swirlie!</span>", "<span class='italics'>You hear a toilet flushing.</span>" );

									if ( GM is Mob_Living_Carbon ) {
										C = GM;

										if ( !Lang13.Bool( ((dynamic)C).v_internal ) ) {
											((dynamic)C).adjustOxyLoss( 5 );
										}
									} else {
										((dynamic)GM).adjustOxyLoss( 5 );
									}
								}
								this.swirlie = null;
							} else {
								GlobalFuncs.playsound( this.loc, "sound/effects/bang.ogg", 25, 1 );
								GM.visible_message( "<span class='danger'>" + user + " slams " + GM.name + " into " + this + "!</span>", "<span class='userdanger'>" + user + " slams " + GM.name + " into " + this + "!</span>" );
								((dynamic)GM).adjustBruteLoss( 5 );
							}
						}
					} else {
						user.WriteMsg( "<span class='warning'>You need a tighter grip!</span>" );
					}
				}
			}

			if ( this.cistern ) {
				
				if ( Convert.ToDouble( A.w_class ) > 3 ) {
					user.WriteMsg( "<span class='warning'>" + A + " does not fit!</span>" );
					return null;
				}

				if ( this.w_items + Convert.ToDouble( A.w_class ) > 5 ) {
					user.WriteMsg( "<span class='warning'>The cistern is full!</span>" );
					return null;
				}

				if ( !Lang13.Bool( user.drop_item() ) ) {
					user.WriteMsg( new Txt( "<span class='warning'>" ).The( A ).item().str( " is stuck to your hand, you cannot put it in the cistern!</span>" ).ToString() );
					return null;
				}
				A.loc = this;
				this.w_items += Convert.ToDouble( A.w_class );
				user.WriteMsg( "<span class='notice'>You carefully place " + A + " into the cistern.</span>" );
				return null;
			}
			return null;
		}

		// Function from file: watercloset.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "toilet" + this.open + this.cistern;
			return false;
		}

		// Function from file: watercloset.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic I = null;

			
			if ( this.swirlie != null ) {
				((Mob)a).changeNext_move( 8 );
				GlobalFuncs.playsound( this.loc, "swing_hit", 25, 1 );
				this.swirlie.visible_message( "<span class='danger'>" + a + " slams the toilet seat onto " + this.swirlie + "'s head!</span>", "<span class='userdanger'>" + a + " slams the toilet seat onto " + this.swirlie + "'s head!</span>", "<span class='italics'>You hear reverberating porcelain.</span>" );
				((dynamic)this.swirlie).adjustBruteLoss( 5 );
				return null;
			}

			if ( this.cistern && !( this.open != 0 ) ) {
				
				if ( !( this.contents.len != 0 ) ) {
					a.WriteMsg( "<span class='notice'>The cistern is empty.</span>" );
					return null;
				} else {
					I = Rand13.PickFromTable( this.contents );

					if ( a is Mob_Living_Carbon_Human ) {
						((Mob)a).put_in_hands( I );
					} else {
						I.loc = GlobalFuncs.get_turf( this );
					}
					a.WriteMsg( "<span class='notice'>You find " + I + " in the cistern.</span>" );
					this.w_items -= Convert.ToDouble( I.w_class );
					return null;
				}
			}
			this.open = !( this.open != 0 ) ?1:0;
			this.update_icon();
			return null;
		}

	}

}