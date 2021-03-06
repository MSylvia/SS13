// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Cards_Cardhand : Obj_Item_Toy_Cards {

		public ByTable currenthand = new ByTable();
		public dynamic choice = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "nanotrasen_hand2";
		}

		public Obj_Item_Toy_Cards_Cardhand ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toys.dm
		public override void apply_card_vars( Obj_Item_Toy_Cards newobj = null, dynamic sourceobj = null ) {
			base.apply_card_vars( newobj, (object)(sourceobj) );
			newobj.deckstyle = sourceobj.deckstyle;
			newobj.icon_state = "" + this.deckstyle + "_hand2";
			newobj.card_hitsound = sourceobj.card_hitsound;
			newobj.card_force = sourceobj.card_force;
			newobj.card_throwforce = sourceobj.card_throwforce;
			newobj.card_throw_speed = sourceobj.card_throw_speed;
			newobj.card_throw_range = sourceobj.card_throw_range;
			newobj.card_attack_verb = sourceobj.card_attack_verb;

			if ( sourceobj.burn_state == -1 ) {
				newobj.burn_state = -1;
			}
			return;
		}

		// Function from file: toys.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Toy_Cards_Singlecard ) {
				
				if ( A.parentdeck == this.parentdeck ) {
					this.currenthand.Add( A.cardname );
					((Mob)user).unEquip( A );
					((Ent_Static)user).visible_message( "" + user + " adds a card to their hand.", "<span class='notice'>You add the " + A.cardname + " to your hand.</span>" );
					this.interact( user );

					if ( this.currenthand.len > 4 ) {
						this.icon_state = "" + this.deckstyle + "_hand5";
					} else if ( this.currenthand.len > 3 ) {
						this.icon_state = "" + this.deckstyle + "_hand4";
					} else if ( this.currenthand.len > 2 ) {
						this.icon_state = "" + this.deckstyle + "_hand3";
					}
					GlobalFuncs.qdel( A );
				} else {
					user.WriteMsg( "<span class='warning'>You can't mix cards from other decks!</span>" );
				}
			}
			return null;
		}

		// Function from file: toys.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Mob cardUser = null;
			Obj_Item_Toy_Cards_Cardhand O = null;
			dynamic choice = null;
			Obj_Item_Toy_Cards_Singlecard C = null;
			Obj_Item_Toy_Cards_Singlecard N = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( Task13.User.stat != 0 || !( Task13.User is Mob_Living_Carbon_Human ) || !Task13.User.canmove ) {
				return null;
			}
			cardUser = Task13.User;
			O = this;

			if ( Lang13.Bool( href_list["pick"] ) ) {
				
				if ( cardUser.get_item_by_slot( 4 ) == this || cardUser.get_item_by_slot( 5 ) == this ) {
					choice = href_list["pick"];
					C = new Obj_Item_Toy_Cards_Singlecard( cardUser.loc );
					this.currenthand.Remove( choice );
					C.parentdeck = this.parentdeck;
					C.cardname = choice;
					C.apply_card_vars( C, O );
					C.pickup( cardUser );
					cardUser.put_in_hands( C );
					cardUser.visible_message( new Txt( "<span class='notice'>" ).item( cardUser ).str( " draws a card from " ).his_her_its_their().str( " hand.</span>" ).ToString(), "<span class='notice'>You take the " + C.cardname + " from your hand.</span>" );
					this.interact( cardUser );

					if ( this.currenthand.len < 3 ) {
						this.icon_state = "" + this.deckstyle + "_hand2";
					} else if ( this.currenthand.len < 4 ) {
						this.icon_state = "" + this.deckstyle + "_hand3";
					} else if ( this.currenthand.len < 5 ) {
						this.icon_state = "" + this.deckstyle + "_hand4";
					}

					if ( this.currenthand.len == 1 ) {
						N = new Obj_Item_Toy_Cards_Singlecard( this.loc );
						N.parentdeck = this.parentdeck;
						N.cardname = this.currenthand[1];
						N.apply_card_vars( N, O );
						cardUser.unEquip( this );
						N.pickup( cardUser );
						cardUser.put_in_hands( N );
						cardUser.WriteMsg( "<span class='notice'>You also take " + this.currenthand[1] + " and hold it.</span>" );
						Interface13.Browse( cardUser, null, "window=cardhand" );
						GlobalFuncs.qdel( this );
					}
				}
				return null;
			}
			return null;
		}

		// Function from file: toys.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			dynamic t = null;
			Browser popup = null;

			dat = "You have:<BR>";

			foreach (dynamic _a in Lang13.Enumerate( this.currenthand )) {
				t = _a;
				
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";pick=" ).item( t ).str( "'>A " ).item( t ).str( ".</A><BR>" ).ToString();
			}
			dat += "Which card will you remove next?";
			popup = new Browser( user, "cardhand", "Hand of Cards", 400, 240 );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: toys.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			((Mob)user).set_machine( this );
			this.interact( user );
			return null;
		}

	}

}