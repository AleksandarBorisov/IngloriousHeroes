namespace IngloriousHeros.Core.UI.DrawModel.Models
{
    public class GnomeModel : IModel
    {
        private readonly string model = @"
                                        
                  (\    /)
                  |_)//(_|
                  |4\_/4)(
                 '( (_  -)D
                   ) _)  /\,__
                 _,\_._,/ /   `)
    \.,_,,      ( _   ~ .   ,   \
     \   (\      \(   \/  _)(    )
      \   \\      )). _______>-. `*
       \  /\\    _'( /   /\  '\  _)
        \( ,\\.-'  '/    \/    \/
         '  \><)_'.)|/\/\/\/\/\|
              \) ,( |\/\/\/\/\/|
              ' ((  \    /\    /
               ((((  \___\/___/)
                ((,) /   ((()   )
                 ""..-,  (()(""   /
                  _//.   ((() .""
          _____ //,/"" ___ ((( ', ___    
                           ((  )
                            / /
                          _/,/'
                        /,/,""
                                        
";

        public string Model
        {
            get => this.model;
        }
    }
}
