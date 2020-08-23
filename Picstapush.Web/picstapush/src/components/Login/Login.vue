<style lang="scss" scoped>
.login-box {
  z-index: 1;
  position: relative;
}
</style>
<template>
  <section class="section">
    <div class="container">
      <div class="column is-offset-one-fifth is-8">
        <div class="box">
          <div class="has-text-centered">
            <h2 class="is-size-1">Picstapush</h2>
          </div>
          <b-field label="Username">
            <b-input placeholder="Username" type="text" icon="user"></b-input>
          </b-field>
          <b-field label="Password">
            <b-input type="Password" placeholder="Password" password-reveal icon="lock"></b-input>
          </b-field>
          <div class="is-centered buttons">
            <button class="button is-outlined is-primary">
              <span class="icon">
                <i class="fas fa-sign-in-alt"></i>
              </span>
              <span>Log in</span>
            </button>
            <button @click="onSignupClicked" class="button is-outlined is-info">
              <span class="icon">
                <i class="fas fa-user-plus"></i>
              </span>
              <span>Sign Up</span>
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
import LoginService from "@/services/account-services/login.service";
import LoginModel from "@/models/login-model";
@Component
export default class Login extends Vue {
  public loginService = new LoginService(this.$http);
  public user = new LoginModel({});
  public isLoading = false;
  public onSignupClicked() {
    this.$router.push("signup");
  }
  public async onLoginClicked() {
    this.isLoading = true;
    try {
      const loginResponse = await this.loginService.login(this.user);
      if (loginResponse.data.tokenString != null) {
        this.$buefy.notification.open({
          message: "You have logged in successfully!",
          type: "is-success",
          hasIcon: true
        });
        this.$store.commit("setUser", loginResponse.data);
      } else {
        this.$buefy.notification.open({
          message:
            "Unable to log in! Please verify your username and password.",
          type: "is-danger",
          position: "is-bottom",
          hasIcon: true
        });
      }
    } catch (error) {
      this.$buefy.notification.open({
        message: "Incorrect username or password. Please try again.",
        type: "is-danger",
        position: "is-bottom",
        hasIcon: true
      });
    } finally {
      this.isLoading = false;
    }
  }
}
</script>
