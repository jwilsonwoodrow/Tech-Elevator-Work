<template>
  <div class="container">
    <table id="tblUsers">
      <thead>
        <tr>
          <th>&nbsp;</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
          <th>Email Address</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <input type="checkbox" name="selectAll" @click="checkAll(this)" />
          </td>
          <td>
            <input
              type="text"
              id="firstNameFilter"
              v-model="filter.firstName"
            />
          </td>
          <td>
            <input type="text" id="lastNameFilter" v-model="filter.lastName" />
          </td>
          <td>
            <input type="text" id="usernameFilter" v-model="filter.username" />
          </td>
          <td>
            <input type="text" id="emailFilter" v-model="filter.emailAddress" />
          </td>
          <td>
            <select id="statusFilter" v-model="filter.status">
              <option value>Show All</option>
              <option value="Active">Active</option>
              <option value="Disabled">Disabled</option>
            </select>
          </td>
          <td>&nbsp;</td>
        </tr>
        <tr
          v-for="user in filteredList"
          v-bind:key="user.id"
          v-bind:class="{ disabled: user.status === 'Disabled' }"
        >
          <td>
            <input
              type="checkbox"
              name="selectBox"
              v-bind:id="user.id"
              v-bind:value="user.id"
              @click="selectUser(user.id)"
            />
          </td>
          <td>{{ user.firstName }}</td>
          <td>{{ user.lastName }}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.emailAddress }}</td>
          <td>{{ user.status }}</td>
          <td>
            <button
              class="btnEnableDisable"
              v-if="user.status === 'Disabled'"
              @click="flipStatus(user.id)"
            >
              Enable
            </button>
            <button
              class="btnEnableDisable"
              v-else
              @click="flipStatus(user.id)"
            >
              Disable
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="all-actions">
      <button v-show="!actionButtonDisabled" @click="enableSelectedUsers()">
        Enable Users
      </button>
      <button v-show="!actionButtonDisabled" @click="disableSelectedUsers()">
        Disable Users
      </button>
      <button v-show="!actionButtonDisabled" @click="deleteSelectedUsers()">
        Delete Users
      </button>
    </div>

    <button v-on:click="showForm = true">Add New User</button>

    <form id="frmAddNewUser" v-show="showForm">
      <div class="field">
        <label for="firstName">First Name:</label>
        <input type="text" name="firstName" v-model="newUser.firstName" />
      </div>
      <div class="field">
        <label for="lastName">Last Name:</label>
        <input type="text" name="lastName" v-model="newUser.lastName" />
      </div>
      <div class="field">
        <label for="username">Username:</label>
        <input type="text" name="username" v-model="newUser.username" />
      </div>
      <div class="field">
        <label for="emailAddress">Email Address:</label>
        <input type="text" name="emailAddress" v-model="newUser.emailAddress" />
      </div>
      <button
        type="submit"
        class="btn save"
        @click="(showForm = false), saveUser()"
      >
        Save User
      </button>
    </form>
  </div>
</template>

<script>
export default {
  name: "user-list",
  data() {
    return {
      allChecked: false,
      showForm: false,
      selectedUserIDs: [],
      filter: {
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "",
      },
      newUser: {
        id: null,
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "Active",
      },
      users: [
        {
          id: 1,
          firstName: "John",
          lastName: "Smith",
          username: "jsmith",
          emailAddress: "jsmith@gmail.com",
          status: "Active",
        },
        {
          id: 2,
          firstName: "Anna",
          lastName: "Bell",
          username: "abell",
          emailAddress: "abell@yahoo.com",
          status: "Active",
        },
        {
          id: 3,
          firstName: "George",
          lastName: "Best",
          username: "gbest",
          emailAddress: "gbest@gmail.com",
          status: "Disabled",
        },
        {
          id: 4,
          firstName: "Ben",
          lastName: "Carter",
          username: "bcarter",
          emailAddress: "bcarter@gmail.com",
          status: "Active",
        },
        {
          id: 5,
          firstName: "Katie",
          lastName: "Jackson",
          username: "kjackson",
          emailAddress: "kjackson@yahoo.com",
          status: "Active",
        },
        {
          id: 6,
          firstName: "Mark",
          lastName: "Smith",
          username: "msmith",
          emailAddress: "msmith@foo.com",
          status: "Disabled",
        },
      ],
    };
  },
  methods: {
    saveUser() {
      this.users.unshift(this.newUser);
    },
    flipStatus(id) {
      if (this.users[id - 1].status === "Disabled") {
        this.users[id - 1].status = "Active";
      } else this.users[id - 1].status = "Disabled";
    },
    selectUser(id) {
      if (!this.selectedUserIDs.includes(id)) {
        this.selectedUserIDs.push(id);
      } else {
        for (let i = 0; i < this.selectedUserIDs.length; i++) {
          if (this.selectedUserIDs[i] === id) {
            this.selectedUserIDs.splice(i, 1);
            i--;
          }
        }
      }
      if (this.selectedUserIDs.length === this.users.length){
        this.allChecked = true;
        let selectAllButton = document.getElementsByName("selectAll")
        selectAllButton[0].checked = true;

      }
    },
    enableSelectedUsers() {
      this.selectedUserIDs.forEach((id) => {
        this.users[id - 1].status = "Active";
      });
    },
    disableSelectedUsers() {
      this.selectedUserIDs.forEach((id) => {
        this.users[id - 1].status = "Disabled";
      });
    },
    deleteSelectedUsers() {
      for (let i = 0; i < this.users.length; i++) {
        if (this.selectedUserIDs.includes(this.users[i].id)) {
          this.users.splice(i, 1);
          i--;
        }
      }
    },
    checkAll() {
      let checkboxes = document.getElementsByName("selectBox");
      if (this.selectedUserIDs.length === this.users.length){
        this.allChecked = true;
      }
      else this.allChecked = false;
      if (this.allChecked === false) {
        this.users.forEach((user) => {
          this.selectUser(user.id);
        });
        for (let i = 0; i < checkboxes.length; i++) {
          checkboxes[i].checked = true;
        }
        this.allChecked = true;
      } else {
        this.selectedUserIDs.splice(0, this.selectedUserIDs.length);
        this.allChecked = false;
        for (let i = 0; i < checkboxes.length; i++) {
          checkboxes[i].checked = false;
        }
      }
    },
  },
  computed: {
    filteredList() {
      let filteredUsers = this.users;
      if (this.filter.firstName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.firstName
            .toLowerCase()
            .includes(this.filter.firstName.toLowerCase())
        );
      }
      if (this.filter.lastName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.lastName
            .toLowerCase()
            .includes(this.filter.lastName.toLowerCase())
        );
      }
      if (this.filter.username != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.username
            .toLowerCase()
            .includes(this.filter.username.toLowerCase())
        );
      }
      if (this.filter.emailAddress != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.emailAddress
            .toLowerCase()
            .includes(this.filter.emailAddress.toLowerCase())
        );
      }
      if (this.filter.status != "") {
        filteredUsers = filteredUsers.filter(
          (user) => user.status === this.filter.status
        );
      }
      return filteredUsers;
    },
    actionButtonDisabled() {
      if (this.selectedUserIDs.length === 0) {
        return true;
      } else return false;
    },
  },
};
</script>

<style scoped>
table {
  margin-top: 20px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  margin-bottom: 20px;
}
th {
  text-transform: uppercase;
}
td {
  padding: 10px;
}
tr.disabled {
  color: red;
}
input,
select {
  font-size: 16px;
}

form {
  margin: 20px;
  width: 350px;
}
.field {
  padding: 10px 0px;
}
label {
  width: 140px;
  display: inline-block;
}
button {
  margin-right: 5px;
}
.all-actions {
  margin-bottom: 40px;
}
.btn.save {
  margin: 20px;
  float: right;
}
</style>
