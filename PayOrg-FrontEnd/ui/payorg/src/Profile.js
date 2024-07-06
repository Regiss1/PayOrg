import React, {Component} from "react";

class Profile extends Component {
    render() {
      return (
        <div>
          <img src={this.props.profilePictureSrc} alt="" width="150" 
     height="100" />
          <h2 >{this.props.name}</h2>
        </div>
      );
    }
  }
   
  Profile.defaultProps = {
    profilePictureSrc: 'https://imgs.mongabay.com/wp-content/uploads/sites/20/2020/09/01173258/127404317_f44bdea9ba_h-1200x800.jpg',
  };
   
export class MyProfiles extends Component {
    render() {
      return (
        <div>
          <h1>My Profiles {console.log("teste")}</h1>
          <Profile
            name="Jane Doe"
          />
          <Profile name="John Smith" />
        </div>
      );
    }
  }