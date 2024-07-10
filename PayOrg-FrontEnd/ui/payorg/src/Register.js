import React, { Component } from 'react';
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import CreateUser from "./BackEndCalls/AuthCalls"
import "./form.css"

export default class Register extends Component {
    constructor(props) {
        super(props)
        this.state = {
            response: {},
            password: "",
            email: "",
            confirmPass: ""
        }


        this.handleInputChange = (e) => {
            switch (e.target.id) {
                case 'email':
                    this.setState({ email: e.target.value })
                    break
                case 'password':
                    this.setState({
                        password: e.target.value

                    })
                    break
                case 'confirmPass':
                    this.setState({
                        confirmPass: e.target.value
                    })
                    break
                default: console.log(e.target.value);
            }
        }
        this.validaSenha = () => {
            return this.state.password === this.state.confirmPass;
        }
        this.validateForm = () => {
            return this.state.email.length > 0 && this.state.password.length > 0 && this.state.confirmPass.length > 0 //});
        }

        this.handleSubmit = async (e) => {

            e.preventDefault();

            let apiResponse = await CreateUser(this.state.email, this.state.password);
            console.log(apiResponse);
            this.setState({
                response: apiResponse
            });

        }
    }

    render() {
        const myStyle = {
            color: "white",
            backgroundColor: "Black",
            padding: "10px",
            fontFamily: "Arial",
            marginTop: "10px",
            border: "25%"
        }

        return (
            <div>
                <div className="Register d-flex justify-content-middle m-6">
                    <h3>Registration Page</h3>
                </div>
                {this.state.response.message != null  && <div style={{color: 'green'}}>{this.state.response.message}</div>}
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="email">
                        <Form.Label> Email </Form.Label>
                        <Form.Control placeholder="E-mail"
                            autoFocus
                            type="email"
                            value={this.state.email}
                            onChange={this.handleInputChange} />
                    </Form.Group>
                    <Form.Group size="lg" controlId="password">
                        <Form.Label> Senha </Form.Label>
                        <Form.Control placeholder="Password"
                            autoFocus
                            type="password"
                            value={this.state.password}
                            onChange={this.handleInputChange} />
                    </Form.Group>
                    <Form.Group controlId="confirmPass">
                        <Form.Label> Confirme a Senha </Form.Label>
                        <Form.Control placeholder="Confirm Password"
                            autoFocus
                            type="password"
                            value={this.state.confirmPass}
                            onChange={this.handleInputChange} />
                    </Form.Group>
                    <Button id="buttonSubmit" style={myStyle} size="lg" type="submit" disabled={!(this.validateForm() && this.validaSenha())}>
                        Submit
                    </Button>
                </Form>
            </div>

        )
    }
}