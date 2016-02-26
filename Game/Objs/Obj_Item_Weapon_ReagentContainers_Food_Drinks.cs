// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks : Obj_Item_Weapon_ReagentContainers_Food {

		public int gulp_size = 5;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 4096;
			this.possible_transfer_amounts = new ByTable(new object [] { 5, 10, 15, 20, 25, 30, 50 });
			this.icon = "icons/obj/drinks.dmi";
		}

		// Function from file: drinks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Drinks ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

		// Function from file: drinks.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			double added_heat = 0;

			
			if ( ((Obj_Item)A).is_hot() != 0 ) {
				added_heat = ((Obj_Item)A).is_hot() / 100;

				if ( this.reagents != null ) {
					this.reagents.chem_temp += added_heat;
					user.WriteMsg( "<span class='notice'>You heat " + this + " with " + A + ".</span>" );
					this.reagents.handle_reactions();
				}
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: drinks.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic trans = null;
			dynamic refill = null;
			dynamic trans2 = null;
			dynamic bro = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Obj_Structure_ReagentDispensers ) {
				
				if ( !Lang13.Bool( target.reagents.total_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + target + " is empty.</span>" );
					return false;
				}

				if ( ( this.reagents.total_volume ??0) >= Convert.ToDouble( this.reagents.maximum_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + this + " is full.</span>" );
					return false;
				}
				trans = ((Reagents)target.reagents).trans_to( this, this.amount_per_transfer_from_this );
				user.WriteMsg( "<span class='notice'>You fill " + this + " with " + trans + " units of the contents of " + target + ".</span>" );
			} else if ( Lang13.Bool( ((Ent_Static)target).is_open_container() ) ) {
				
				if ( !Lang13.Bool( this.reagents.total_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + this + " is empty.</span>" );
					return false;
				}

				if ( ( target.reagents.total_volume ??0) >= Convert.ToDouble( target.reagents.maximum_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + target + " is full.</span>" );
					return false;
				}
				refill = this.reagents.get_master_reagent_id();
				trans2 = this.reagents.trans_to( target, this.amount_per_transfer_from_this );
				user.WriteMsg( "<span class='notice'>You transfer " + trans2 + " units of the solution to " + target + ".</span>" );

				if ( user is Mob_Living_Silicon_Robot ) {
					bro = user;
					((Obj_Item_Weapon_StockParts_Cell)bro.cell).use( 30 );
					Task13.Schedule( 600, (Task13.Closure)(() => {
						this.reagents.add_reagent( refill, trans2 );
						return;
					}));
				}
			}
			return false;
		}

		// Function from file: drinks.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			double? fraction = null;

			
			if ( !( this.reagents != null ) || !Lang13.Bool( this.reagents.total_volume ) ) {
				user.WriteMsg( "<span class='warning'>" + this + " is empty!</span>" );
				return false;
			}

			if ( !this.canconsume( M, user ) ) {
				return false;
			}

			if ( M == user ) {
				M.WriteMsg( "<span class='notice'>You swallow a gulp of " + this + ".</span>" );
			} else {
				((Ent_Static)M).visible_message( "<span class='danger'>" + user + " attempts to feed the contents of " + this + " to " + M + ".</span>", "<span class='userdanger'>" + user + " attempts to feed the contents of " + this + " to " + M + ".</span>" );

				if ( !GlobalFuncs.do_mob( user, M ) ) {
					return false;
				}

				if ( !( this.reagents != null ) || !Lang13.Bool( this.reagents.total_volume ) ) {
					return false;
				}
				((Ent_Static)M).visible_message( "<span class='danger'>" + user + " feeds the contents of " + this + " to " + M + ".</span>", "<span class='userdanger'>" + user + " feeds the contents of " + this + " to " + M + ".</span>" );
				GlobalFuncs.add_logs( user, M, "fed", this.reagentlist( this ) );
			}
			fraction = Num13.MinInt( ((int)( this.gulp_size / ( this.reagents.total_volume ??0) )), 1 );
			this.reagents.reaction( M, GlobalVars.INGEST, fraction );
			this.reagents.trans_to( M, this.gulp_size );
			GlobalFuncs.playsound( M.loc, "sound/items/drink.ogg", Rand13.Int( 10, 50 ), 1 );
			return true;
		}

		// Function from file: drinks.dm
		public override void on_reagent_change(  ) {
			
			if ( this.gulp_size < 5 ) {
				this.gulp_size = 5;
			} else {
				this.gulp_size = Num13.MaxInt( Num13.Floor( ( this.reagents.total_volume ??0) / 5 ), 5 );
			}
			return;
		}

	}

}