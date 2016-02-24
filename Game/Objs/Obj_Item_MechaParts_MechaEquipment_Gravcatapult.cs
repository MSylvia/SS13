// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Gravcatapult : Obj_Item_MechaParts_MechaEquipment {

		public dynamic locked = null;
		public double? mode = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "bluespace=2;magnets=3";
			this.equip_cooldown = 10;
			this.energy_drain = 100;
			this.range = 3;
			this.icon_state = "mecha_teleport";
		}

		public Obj_Item_MechaParts_MechaEquipment_Gravcatapult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: other_tools.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			base.Topic( href, href_list, (object)(hsrc) );

			if ( Lang13.Bool( href_list["mode"] ) ) {
				this.mode = String13.ParseNumber( href_list["mode"] );
				GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", new Txt().Ref( this ).ToString(), this.get_equip_info() );
			}
			return null;
		}

		// Function from file: other_tools.dm
		public override string get_equip_info(  ) {
			return new Txt().item( base.get_equip_info() ).str( " " ).item( ( this.mode == 1 ? "(" + ( Lang13.Bool( this.locked ) || Lang13.Bool( "Nothing" ) ) + ")" : null ) ).str( " [<a href='?src=" ).Ref( this ).str( ";mode=1'>S</a>|<a href='?src=" ).Ref( this ).str( ";mode=2'>P</a>]" ).ToString();
		}

		// Function from file: other_tools.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj )]
		public override bool f_action( dynamic target = null ) {
			ByTable atoms = null;
			Ent_Dynamic A = null;
			int iter = 0;
			double i = 0;
			dynamic T = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}

			switch ((int?)( this.mode )) {
				case 1:
					
					if ( !Lang13.Bool( this.locked ) ) {
						
						if ( !( target is Ent_Dynamic ) || Lang13.Bool( target.anchored ) ) {
							this.occupant_message( "Unable to lock on " + target );
							return false;
						}
						this.locked = target;
						this.occupant_message( "Locked on " + target );
						GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", new Txt().Ref( this ).ToString(), this.get_equip_info() );
					} else if ( target != this.locked ) {
						
						if ( Map13.FetchInView( null, this.chassis ).Contains( this.locked ) ) {
							((Ent_Dynamic)this.locked).throw_at( target, 14, 1.5 );
							this.locked = null;
							GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", new Txt().Ref( this ).ToString(), this.get_equip_info() );
							return true;
						} else {
							this.locked = null;
							this.occupant_message( "Lock on " + this.locked + " disengaged." );
							GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", new Txt().Ref( this ).ToString(), this.get_equip_info() );
						}
					}
					break;
				case 2:
					atoms = new ByTable();

					if ( target is Tile ) {
						atoms = Map13.FetchInRange( target, 3 );
					} else {
						atoms = Map13.FetchInRangeExcludeThis( target, 3 );
					}

					foreach (dynamic _b in Lang13.Enumerate( atoms, typeof(Ent_Dynamic) )) {
						A = _b;
						

						if ( Lang13.Bool( A.anchored ) ) {
							continue;
						}
						Task13.Schedule( 0, (Task13.Closure)(() => {
							iter = 5 - Map13.GetDistance( A, target );

							foreach (dynamic _a in Lang13.IterateRange( 0, iter )) {
								i = _a;
								
								Map13.StepAway( A, target, null );
								Task13.Sleep( 2 );
							}
							return;
						}));
					}
					T = GlobalFuncs.get_turf( target );
					GlobalFuncs.log_game( "" + ((dynamic)this.chassis.occupant).ckey + "(" + this.chassis.occupant + ") used a Gravitational Catapult in (" + T.x + "," + T.y + "," + T.z + ")" );
					return true;
					break;
			}
			return false;
		}

	}

}