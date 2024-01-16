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
            <th scope="col">Deadline</th>
        </tr>
    </thead>
    <tbody>
        {#each data || [] as item}
            {@const timeIsUp = item.deadline && new Date().getTime() > new Date(item.deadline).getTime()}
            <tr class:bg-danger={timeIsUp} class:text-white={timeIsUp}>
                <th scope="row">{item.id}</th>
                <td>
                    <a href="/translations/{item.id}">{item.title}</a>
                </td>
                <td>{item.createdBy.name}</td>
                <td>{item.assignedTo ? item.assignedTo.name : ""}</td>
                <td>{item.sourceLanguage.title}</td>
                <td>{item.targetLanguage.title}</td>
                <td>{item.deadline ? new Date(item.deadline).toLocaleDateString() : ''}</td>
            </tr>
        {/each}
    </tbody>
</table>
