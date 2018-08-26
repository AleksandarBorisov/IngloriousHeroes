namespace IngloriousHeros.Core.UI.DrawModel.Models
{
    public class WarriorModel : IModel
    {
        private readonly string model = @"
                     ,dM
                   dMMP
                  dMMM'
                  \MM/
                  dMMm.
                 dMMP'_\---.
                _| _ p;88;`.
              ,db; p >  ;8P|  `.
             (``T8b,__,'dP |   |
             |   `Y8b..dP  ;_  |
             |    |`T88P_ /  `\;
             :_.-~|d8P'`Y/    /
              \_ TP;   7`\
   ,,__        >   `._  /'  /   `\_
   `._ """"""""~~~~------|`\;' ;     ,'
      """"""~~~-----~~~'\__[|;' _.-'  `\   
              ;--..._.-'-._     ;
             /      /`~~""'   ,'`\_ ,/
            ;_    /'        /    ,/
            | `~-l         ;    /
            `\    ;       /\.._|
              \    \      \     \
              /`---';      `----'
             (     /            
              `---'";

        public string Model
        {
            get => this.model;
        }
    }
}
