// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_WinterGift_Special : Obj_Item_Weapon_WinterGift {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "gift_winter-4";
			this.icon_state = "gift_winter-4";
		}

		public Obj_Item_Weapon_WinterGift_Special ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gift_wrappaper.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic gift_type = null;
			dynamic I = null;
			string additional_info = null;
			dynamic B = null;
			string log_str = null;

			gift_type = Rand13.Pick(new object [] { typeof(Obj_Item_Device_FuseBomb), typeof(Obj_Item_Weapon_Card_Emag), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Apple_Poisoned), typeof(Obj_Item_Weapon_Tome) });
			I = Lang13.Call( gift_type, user );
			((Mob)user).u_equip( this, false );
			((Mob)user).put_in_hands( I );
			((Ent_Static)I).add_fingerprint( user );
			additional_info = "";

			if ( I is Obj_Item_Device_FuseBomb ) {
				B = I;
				B.fuse_lit = true;
				B.update_icon();
				((Obj_Item_Device_FuseBomb)B).fuse_burn();
				additional_info = ", OH SHIT its fuse is lit!";
			}
			log_str = "" + user.name + "(" + user.ckey + ") openned <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + I.x + ";Y=" + I.y + ";Z=" + I.z + "'>a black gift</a> and found " + I.name + " inside" + additional_info + ".";

			if ( Lang13.Bool( user ) ) {
				log_str += new Txt( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( user ).str( "'>?</A>)" ).ToString();
			}
			GlobalFuncs.message_admins( log_str );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + log_str ) );
			GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You unwrapped " ).a( I ).item().item( additional_info ).str( "!</span>" ).ToString() );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}