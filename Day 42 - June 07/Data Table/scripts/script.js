document.addEventListener("DOMContentLoaded", () => {
  const tableBody = document.getElementById("customer-table-body");
  let sortOrder = {
    id: "asc",
    name: "asc",
    status: "asc",
  };

  function renderTable(customers) {
    tableBody.innerHTML = "";
    customers.forEach((customer) => {
      const row = document.createElement("tr");
      row.innerHTML = `
        <td><input type="checkbox" /></td>
        <td>${customer.id}</td>
        <td>
          <div>${customer.name}</div>
          <small>${customer.phone}</small>
        </td>
        <td>${customer.description}</td>
        <td><span class="badge ${customer.statusClass}">${customer.status}</span></td>
        <td>
          ${customer.rate}
          <small> CAD </small>
        </td>
        <td class="${customer.balanceClass}">
          ${customer.balance}
          <small> CAD </small>
        </td>
        <td>
          <div>${customer.deposit}</div>
          <small>CAD</small>
        </td>
      `;
      tableBody.appendChild(row);
    });
  }

  function sortCustomers(field) {
    const sortOrderField = sortOrder[field];
    customers.sort((a, b) => {
      if (field === "id") {
        return sortOrderField === "asc" ? a.id - b.id : b.id - a.id;
      } else if (field === "name") {
        return sortOrderField === "asc"
          ? a.name.localeCompare(b.name)
          : b.name.localeCompare(a.name);
      } else if (field === "status") {
        return sortOrderField === "asc"
          ? a.status.localeCompare(b.status)
          : b.status.localeCompare(a.status);
      }
    });
    sortOrder[field] = sortOrderField === "asc" ? "desc" : "asc";
    renderTable(customers);
  }

  renderTable(customers);

  document.getElementById("sort-id").addEventListener("click", () => {
    sortCustomers("id");
  });

  document.getElementById("sort-name").addEventListener("click", () => {
    sortCustomers("name");
  });

  document.getElementById("sort-status").addEventListener("click", () => {
    sortCustomers("status");
  });
});
