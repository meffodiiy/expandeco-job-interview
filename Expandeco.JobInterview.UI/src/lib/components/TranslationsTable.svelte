<script>
    export let data = [];
</script>

<table class="table table-striped">
    <thead>
        <tr>
            <th scope="col">#</th>
            <th scope="col">Title</th>
            <th scope="col">Created by</th>
            <th scope="col">Assigned to</th>
            <th scope="col">Source language</th>
            <th scope="col">Target language</th>
        </tr>
    </thead>
    <tbody>
        {#each data || [] as item}
            <tr>
                <th scope="row">{item.id}</th>
                <td>
                    <a href="/translations/{item.id}">{item.title}</a>
                </td>
                <td>{item.createdBy.name}</td>
                <td>{item.assignedTo ? item.assignedTo.name : ""}</td>
                <td>{item.sourceLanguage.title}</td>
                <td>{item.targetLanguage.title}</td>
            </tr>
        {/each}
    </tbody>
</table>
