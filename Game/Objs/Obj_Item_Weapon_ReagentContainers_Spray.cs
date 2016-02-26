// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Spray : Obj_Item_Weapon_ReagentContainers {

		public int spray_maxrange = 3;
		public int spray_currentrange = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cleaner";
			this.flags = 4100;
			this.slot_flags = 512;
			this.w_class = 2;
			this.throw_speed = 3;
			this.volume = 250;
			this.possible_transfer_amounts = new ByTable();
			this.icon = "icons/obj/janitor.dmi";
			this.icon_state = "cleaner";
		}

		public Obj_Item_Weapon_ReagentContainers_Spray ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: spray.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.amount_per_transfer_from_this = ( this.amount_per_transfer_from_this == 10 ? 5 : 10 );
			this.spray_currentrange = ( this.spray_currentrange == 1 ? this.spray_maxrange : 1 );
			user.WriteMsg( "<span class='notice'>You " + ( this.amount_per_transfer_from_this == 10 ? "remove" : "fix" ) + " the nozzle. You'll now use " + this.amount_per_transfer_from_this + " units per spray.</span>" );
			return null;
		}

		// Function from file: spray.dm
		public virtual void spray( dynamic A = null ) {
			int? range = null;
			Obj_Effect_Decal_Chempuff D = null;
			int? puff_reagent_left = null;
			int wait_step = 0;
			int? i = null;
			Ent_Static T = null;

			range = Num13.MaxInt( Num13.MinInt( this.spray_currentrange, Map13.GetDistance( this, A ) ), 1 );
			D = new Obj_Effect_Decal_Chempuff( GlobalFuncs.get_turf( this ) );
			D.create_reagents( this.amount_per_transfer_from_this );
			this.reagents.trans_to( D, this.amount_per_transfer_from_this, 1 / ( range ??0) );
			D.color = GlobalFuncs.mix_color_from_reagents( D.reagents.reagent_list );
			puff_reagent_left = range;
			wait_step = Num13.MaxInt( Num13.Floor( 3 / ( range ??0) + 2 ), 2 );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				i = null;
				i = 0;

				while (( i ??0) < ( range ??0)) {
					Map13.StepTowardsSimple( D, A );
					Task13.Sleep( wait_step );

					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( D ), typeof(Ent_Static) )) {
						T = _a;
						

						if ( T == D || T.invisibility != 0 ) {
							continue;
						}

						if ( ( puff_reagent_left ??0) <= 0 ) {
							break;
						}
						D.reagents.reaction( T, GlobalVars.VAPOR );

						if ( T is Mob ) {
							puff_reagent_left -= 1;
						}
					}

					if ( ( puff_reagent_left ??0) > 0 ) {
						D.reagents.reaction( GlobalFuncs.get_turf( D ), GlobalVars.VAPOR );
						puff_reagent_left -= 1;
					}

					if ( ( puff_reagent_left ??0) <= 0 ) {
						GlobalFuncs.qdel( D );
						return;
					}
					i++;
				}
				GlobalFuncs.qdel( D );
				return;
			}));
			return;
		}

		// Function from file: spray.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic trans = null;
			dynamic T = null;

			
			if ( target is Obj_Item_Weapon_Storage || target is Obj_Structure_Table || target is Obj_Structure_Rack || target is Obj_Structure_Closet || target is Obj_Item_Weapon_ReagentContainers || target is Obj_Structure_Sink || target is Obj_Structure_Janitorialcart || target is Obj_Machinery_Hydroponics ) {
				return false;
			}

			if ( target is Obj_Effect_ProcHolder_Spell ) {
				return false;
			}

			if ( target is Obj_Structure_ReagentDispensers && Map13.GetDistance( this, target ) <= 1 ) {
				
				if ( !Lang13.Bool( target.reagents.total_volume ) && Lang13.Bool( target.reagents ) ) {
					user.WriteMsg( new Txt( "<span class='notice'>" ).The( target ).item().str( " is empty.</span>" ).ToString() );
					return false;
				}

				if ( ( this.reagents.total_volume ??0) >= Convert.ToDouble( this.reagents.maximum_volume ) ) {
					user.WriteMsg( new Txt( "<span class='notice'>" ).The( this ).item().str( " is full.</span>" ).ToString() );
					return false;
				}
				trans = ((Reagents)target.reagents).trans_to( this, 50 );
				user.WriteMsg( new Txt( "<span class='notice'>You fill " ).the( this ).item().str( " with " ).item( trans ).str( " units of the contents of " ).the( target ).item().str( ".</span>" ).ToString() );
				return false;
			}

			if ( ( this.reagents.total_volume ??0) < ( this.amount_per_transfer_from_this ??0) ) {
				user.WriteMsg( new Txt( "<span class='warning'>" ).The( this ).item().str( " is empty!</span>" ).ToString() );
				return false;
			}
			this.spray( target );
			GlobalFuncs.playsound( this.loc, "sound/effects/spray2.ogg", 50, 1, -6 );
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).newtonian_move( Map13.GetDistance( target, user ) );
			T = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( this.reagents.has_reagent( "sacid" ) ) ) {
				GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( user ) ).str( " fired sulphuric acid from " ).a( this ).item().str( " at (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>" ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")</a>)." ).ToString() );
				GlobalFuncs.log_game( new Txt().item( GlobalFuncs.key_name( user ) ).str( " fired sulphuric acid from " ).a( this ).item().str( " at " ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")." ).ToString() );
			}

			if ( Lang13.Bool( this.reagents.has_reagent( "facid" ) ) ) {
				GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( user ) ).str( " fired Fluacid from " ).a( this ).item().str( " at (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>" ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")</a>)." ).ToString() );
				GlobalFuncs.log_game( new Txt().item( GlobalFuncs.key_name( user ) ).str( " fired Fluacid from " ).a( this ).item().str( " at " ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")." ).ToString() );
			}

			if ( Lang13.Bool( this.reagents.has_reagent( "lube" ) ) ) {
				GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( user ) ).str( " fired Space lube from " ).a( this ).item().str( " at (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>" ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")</a>)." ).ToString() );
				GlobalFuncs.log_game( new Txt().item( GlobalFuncs.key_name( user ) ).str( " fired Space lube from " ).a( this ).item().str( " at " ).item( GlobalFuncs.get_area( this ) ).str( " (" ).item( T.x ).str( ", " ).item( T.y ).str( ", " ).item( T.z ).str( ")." ).ToString() );
			}
			return false;
		}

		// Function from file: spray.dm
		[Verb]
		[VerbInfo( name: "Empty Spray Bottle", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void empty(  ) {
			
			if ( Task13.User.incapacitated() ) {
				return;
			}

			if ( Interface13.Alert( Task13.User, "Are you sure you want to empty that?", "Empty Bottle:", "Yes", "No" ) != "Yes" ) {
				return;
			}

			if ( Task13.User.loc is Tile && this.loc == Task13.User ) {
				Task13.User.WriteMsg( new Txt( "<span class='notice'>You empty " ).the( this ).item().str( " onto the floor.</span>" ).ToString() );
				this.reagents.reaction( Task13.User.loc );
				this.reagents.clear_reagents();
			}
			return;
		}

	}

}