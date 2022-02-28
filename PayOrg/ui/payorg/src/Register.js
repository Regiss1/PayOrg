import React,{Component} from 'react';
import { variables } from './Variables.js';
export class Register extends Component{
    constructor(props){
        super(props);
        
    }
render(){
    const mystyle = {
        color: "white",
        backgroundColor: "Black",
        padding: "10px",
        fontFamily: "Arial",
        marginTop: "10px",
        border: "25%"
      };
    return(
        <div>
        <div class="d-flex justify-content-middle m-3">
            <h3>Registration Page</h3>
            </div>
            <form>
            <div class="m-12">
            <input type="text" placeholder="Email" name="email"></input>
            </div>
            <div>
            <input type="password" placeholder="Password" name="password"></input>
            <div >
            <button style={mystyle} class ="btn btn-light btn-outline-primary">Submit</button>
            </div></div></form> 
        </div>

    )
}
}