namespace IngloriousHeros.Core.UI.DrawModel.Models
{
    public class WizzardModel : IModel
    {
        private readonly string model = @"
                                       
                     ____
                   .'* *.'
                __/_*_*(_
               / _______ \
              _\_)/___\(_/_
             / _((\- -/))_ \
             \ \())(-)(()/ /
              ' \(((()))/ '
             / ' \)).))/ ' \
            / _ \ - | - /_  \
           (   ( .;''';. .'  )
           _\""__ /    )\ __""/_
             \/  \   ' /  \/
              .'  '...' ' )
               / /  |  \ \
              / .   .   . \
             /   .     .   \
            /   /   |   \   \
          .'   /    b    '.  '.
      _.-'    /     Bb     '-. '-._
  _.-'       |      BBb       '-.  '-.
 (________mrf\____.dBBBb.________)____) 
";

        public string Model
        {
            get => this.model;
        }
    }
}
