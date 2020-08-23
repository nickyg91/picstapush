<template>
  <section class="section">
    <div class="container">
      <div class="column is-offset-one-fifth is-8">
        <b-loading active.sync="isLoading"></b-loading>
        <div class="box">
          <div class="has-text-centered">
            <h2 class="is-size-1">Sign Up</h2>
          </div>
          <div class="container">
            <b-field label="Email">
              <b-input
                v-on:input="onFormChanged"
                required
                validation-message="Email is required."
                min="8"
                max="64"
                placeholder="Email"
                v-model="user.email"
                type="text"
                icon="user"
              ></b-input>
            </b-field>
            <b-field label="Username">
              <b-input
                v-on:input="onFormChanged"
                required
                validation-message="Username is required."
                min="8"
                max="64"
                placeholder="Username"
                v-model="user.username"
                type="text"
                icon="envelope"
              ></b-input>
            </b-field>
            <b-field label="Password">
              <b-input
                v-on:input="onFormChanged"
                required
                validation-message="Password is required and must contain at 8-32 characters with uppercase and lowercase letters, symbol, and number."
                type="Password"
                pattern="(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]]:;<>,.?\/~_+-=|).{8,32}"
                placeholder="Password"
                v-model="user.password"
                password-reveal
                icon="lock"
              ></b-input>
            </b-field>
            <b-field label="Confirm Password">
              <b-input
                :custom-class="
                  user.confirmPassword != user.password ? 'is-danger ' : ''
                "
                v-on:input="onFormChanged"
                type="Password"
                placeholder="Confirm Password"
                v-model="user.confirmPassword"
                password-reveal
                required
                validation-message="Field is required and must match the password field."
                icon="lock"
              ></b-input>
            </b-field>
            <div
              class="help has-text-danger"
              v-if="user.confirmPassword != user.password"
            >Passwords do not match!</div>
          </div>
          <div class="mt-5 is-centered buttons">
            <button
              :disabled="!validForm"
              @click="onCreateClicked"
              class="button is-fullwidth is-outlined is-primary"
            >
              <span class="icon">
                <i class="fas fa-save"></i>
              </span>
              <span>Create Account</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import CreateAccountService from "@/services/account-services/create-account.service";
import { ValidationProvider } from "vee-validate";
import SignupModel from "@/models/signup-model";
@Component({
  components: {
    ValidationProvider
  }
})
export default class SignUp extends Vue {
  private signupService = new CreateAccountService(this.$http);
  public user: SignupModel = new SignupModel();
  public isLoading = false;
  public passwordRegex = new RegExp(
    /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]]:;<>,.?\/~_+-=|).{8,32}$/
  );
  public validForm = false;
  public async onCreateClicked() {
    this.isLoading = true;
    try {
      const response = await this.signupService.createAccount(this.user);
      if (response.data) {
        this.$buefy.notification.open({
          message: "Account created successfully!",
          type: "is-success",
          hasIcon: true,
          position: "is-bottom"
        });
        this.$router.push("login");
      }
    } catch (error) {
      let message = "An error occurred while creating your account!";
      if (error.response.status === 400 && error.response.errors) {
        message = "Please make sure that the form is valid.";
      }
      this.$buefy.notification.open({
        message: message,
        type: "is-danger",
        hasIcon: true,
        position: "is-bottom"
      });
    } finally {
      this.isLoading = false;
    }
  }

  public onFormChanged() {
    this.validForm =
      this.user.username != undefined &&
      this.user.email != undefined &&
      this.user.password == this.user.confirmPassword &&
      this.passwordRegex.test(this.user.password) &&
      this.user.password.length <= 32 &&
      this.user.password.length >= 6;
  }
}
</script>
